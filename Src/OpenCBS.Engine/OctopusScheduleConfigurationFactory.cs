using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.Engine.DatePolicy;
using OpenCBS.Engine.Interfaces;
using OpenCBS.Engine.PeriodPolicy;
using OpenCBS.Enums;
using OpenCBS.Shared;
using OpenCBS.Shared.Settings;

namespace OpenCBS.Engine
{
    public class OctopusScheduleConfigurationFactory : IScheduleConfigurationFactory
    {
        private IScheduleConfiguration _scheduleConfiguration;
        private readonly CompositionContainer _container;

        [ImportMany(typeof(IPolicy))]
        private Lazy<IPolicy, IPolicyAttribute>[] Policies { get; set; }

        public OctopusScheduleConfigurationFactory(NonWorkingDateSingleton nonWorkingDate)
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            _container = new CompositionContainer(catalog);
            var weekendPolicy = new WeekendPolicy();
            weekendPolicy.AddWeekend((DayOfWeek)nonWorkingDate.WeekEndDay1);
            weekendPolicy.AddWeekend((DayOfWeek)nonWorkingDate.WeekEndDay2);
            var holidayPolicy = new HolidayPolicy();
            foreach (var pair in nonWorkingDate.PublicHolidays)
            {
                holidayPolicy.AddHoliday(pair.Key);
            }
            var nonWorkingDayPolicy = new NonWorkingDayPolicy(weekendPolicy, holidayPolicy);
            _container.ComposeExportedValue<INonWorkingDayPolicy>(nonWorkingDayPolicy);
        }

        public OctopusScheduleConfigurationFactory Init()
        {
            Compose();
            _scheduleConfiguration = new ScheduleConfiguration();
            return this;
        }

        public OctopusScheduleConfigurationFactory WithSettings(ApplicationSettings settings)
        {
            return this;
        }

        public OctopusScheduleConfigurationFactory WithLoan(Loan loan)
        {
            if (loan == null) throw new ArgumentException("Loan cannot be null.");
            if (loan.Product == null) throw new ArgumentException("Loan product cannot be null.");
            _scheduleConfiguration.CalculationPolicy = GetPolicy<IInstallmentCalculationPolicy>(GetCalculationPolicyKey(loan));
            _scheduleConfiguration.PeriodPolicy = GetPeriodPolicy(loan);
            _scheduleConfiguration.YearPolicy = GetPolicy<IYearPolicy>("360");
            _scheduleConfiguration.RoundingPolicy = GetRoundingPolicy(loan);
            return this;
        }

        public IScheduleConfiguration GetConfiguration()
        {
            return _scheduleConfiguration;
        }

        private void Compose()
        {
            _container.SatisfyImportsOnce(this);
        }

        private string GetCalculationPolicyKey(Loan loan)
        {
            var map = new Dictionary<OLoanTypes, string>
            {
                { OLoanTypes.Flat, "Flat" },
                { OLoanTypes.DecliningFixedInstallments, "Annuity" },
                { OLoanTypes.DecliningFixedPrincipal, "Fixed principal" },
            };
            return map.ContainsKey(loan.Product.LoanType) ? map[loan.Product.LoanType] : string.Empty;
        }

        private IPeriodPolicy GetPeriodPolicy(Loan loan)
        {
            if (loan.InstallmentType.NbOfMonths == 1 && loan.InstallmentType.NbOfDays == 0)
                return GetPolicy<IPeriodPolicy>("Monthly (30 day)");
            if (loan.InstallmentType.NbOfMonths == 0 && loan.InstallmentType.NbOfDays == 1)
                return GetPolicy<IPeriodPolicy>("Daily");
            
            var policy = (CustomPeriodPolicy) GetPolicy<IPeriodPolicy>("Custom");
            policy.SetNumberOfDays(loan.InstallmentType.NbOfDays);
            return policy;
        }

        private IRoundingPolicy GetRoundingPolicy(Loan loan)
        {
            var key = loan.Product.Currency.UseCents ? "Two decimal" : "Whole";
            return GetPolicy<IRoundingPolicy>(key);
        }

        private T GetPolicy<T>(string key) where T : IPolicy
        {
            return (T)(from policy in Policies
                       where policy.Metadata.Implementation == key
                       && policy.Value.GetType().GetInterfaces().Contains(typeof(T))
                       select policy.Value).FirstOrDefault();
        }
    }
}
