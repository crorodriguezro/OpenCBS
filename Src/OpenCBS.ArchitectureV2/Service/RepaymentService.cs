using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.CoreDomain.Events;
using OpenCBS.Enums;
using OpenCBS.Services;

namespace OpenCBS.ArchitectureV2.Service
{
    public class RepaymentService : IRepaymentService
    {
        public RepaymentSettings Settings { get; set; }

        public RepaymentService()
        {
            Settings = new RepaymentSettings();
        }

        public Loan Repay()
        {
            var newSettings = (RepaymentSettings)Settings.Clone();
            var script = RunScript(newSettings.ScriptName);
            if (newSettings.DateChanged)
                script.GetInitAmounts(newSettings);
            if (newSettings.AmountChanged)
                script.GetAmounts(newSettings);
            script.Repay(newSettings);
            var events = GenerateRepaymentEvents(Settings, newSettings);
            newSettings.Loan.Events.Add(events);
            Settings = newSettings;
            return Settings.Loan;
        }

        public Dictionary<string, string> GetAllRepaymentScriptsWithTypes()
        {
            var scripts = new Dictionary<string, string>();
            var files = Directory
                .EnumerateFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts\\Repayment\\"), "*.py",
                                SearchOption.AllDirectories)
                .Select(Path.GetFileName);
            foreach (var file in files)
            {
                var script = RunScript(file);
                scripts.Add(file, script.GetType());
            }
            return scripts;
        }

        private static dynamic RunScript(string scriptName)
        {
            var options = new Dictionary<string, object>();
#if DEBUG
            options["Debug"] = true;
#endif
            ScriptEngine engine = Python.CreateEngine(options);
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts\\Repayment\\" + scriptName);
            
            var assemby = typeof(ServicesProvider).Assembly;
            engine.Runtime.LoadAssembly(assemby);
            assemby = typeof(Installment).Assembly;
            engine.Runtime.LoadAssembly(assemby);

            return engine.ExecuteFile(file);
        }

        private static EventStock GenerateRepaymentEvents(RepaymentSettings oldConfig, RepaymentSettings newConfig)
        {
            var events = new EventStock();
            foreach (var installment in oldConfig.Loan.InstallmentList)
            {
                if (installment.IsRepaid) continue;
                var newInstallment = newConfig.Loan.GetInstallment(installment.Number - 1);
                if (newInstallment.CapitalRepayment != installment.CapitalRepayment)
                {
                    events.Add(new RepaymentEvent
                    {
                        Principal = newInstallment.PaidCapital - installment.PaidCapital,
                        Interests = newInstallment.PaidInterests - installment.PaidInterests,
                        Penalties = newInstallment.PaidFees - installment.PaidFees,
                        Commissions = newInstallment.PaidCommissions - installment.PaidCommissions,
                        Date = oldConfig.Date,
                        InstallmentNumber = installment.Number,
                        PastDueDays =
                            newInstallment.ExpectedDate > oldConfig.Date
                                ? 0
                                : (oldConfig.Date - newInstallment.ExpectedDate).Days,
                        PaymentMethod = oldConfig.PaymentMethod,
                        Comment = oldConfig.Comment,
                        RepaymentType = OPaymentType.PartialPayment,
                        User = User.CurrentUser
                    });
                    newInstallment.PaidDate = newConfig.Date;
                    break;
                }
                if (newInstallment.PaidCapital <= installment.PaidCapital &&
                    newInstallment.PaidInterests <= installment.PaidInterests &&
                    newInstallment.PaidFees <= installment.PaidFees &&
                    newInstallment.PaidCommissions <= installment.PaidCommissions) continue;
                if (newInstallment.ExpectedDate > oldConfig.Date)
                {
                    events.Add(new RepaymentEvent
                        {
                            Principal = newInstallment.PaidCapital - installment.PaidCapital,
                            Interests = newInstallment.PaidInterests - installment.PaidInterests,
                            Penalties = newInstallment.PaidFees - installment.PaidFees,
                            Commissions = newInstallment.PaidCommissions - installment.PaidCommissions,
                            InstallmentNumber = installment.Number,
                            Date = oldConfig.Date,
                            PastDueDays = 0,
                            PaymentMethod = oldConfig.PaymentMethod,
                            Comment = oldConfig.Comment,
                            RepaymentType = OPaymentType.StandardPayment,
                            User = User.CurrentUser
                        });
                    newInstallment.PaidDate = newConfig.Date;
                }
                else
                {
                    events.Add(new BadLoanRepaymentEvent
                        {
                            Principal = newInstallment.PaidCapital - installment.PaidCapital,
                            Interests = newInstallment.PaidInterests - installment.PaidInterests,
                            Penalties = newInstallment.PaidFees - installment.PaidFees,
                            Commissions = newInstallment.PaidCommissions - installment.PaidCommissions,
                            InstallmentNumber = installment.Number,
                            Date = oldConfig.Date,
                            PastDueDays = (oldConfig.Date - newInstallment.ExpectedDate).Days,
                            PaymentMethod = oldConfig.PaymentMethod,
                            Comment = oldConfig.Comment,
                            RepaymentType = OPaymentType.StandardPayment,
                            User = User.CurrentUser
                        });
                    newInstallment.PaidDate = newConfig.Date;
                }
            }
            return events;
        }
    }
}
