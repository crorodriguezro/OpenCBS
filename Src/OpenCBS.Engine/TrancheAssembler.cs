using System.Collections.Generic;
using System.Linq;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class TrancheAssembler
    {
        public IEnumerable<IInstallment> AssembleTranche(
            IEnumerable<IInstallment> schedule,
            IScheduleConfiguration scheduleConfiguration,
            ITrancheConfiguration trancheConfiguration,
            IScheduleBuilder scheduleBuilder,
            ITrancheBuilder trancheBuilder)
        {
            // Build a new combined schedule
            var trancheSchedule = trancheBuilder.BuildTranche(schedule, scheduleBuilder, scheduleConfiguration, trancheConfiguration);

            // Get an interested paid in advance, whereas "in advance" means after the new tranche date
            var overpaidInterest = (
                from installment in schedule
                where installment.RepaymentDate > trancheConfiguration.StartDate
                select installment
            ).Sum(installment => installment.PaidInterest);

            // Get the part of the schedule that comes before the tranche date...
            var newSchedule =
                from installment in schedule
                where installment.RepaymentDate <= trancheConfiguration.StartDate
                select installment;

            // ...and force close it (set expected equal to paid)
            var olbDifference = 0m;
            foreach (var installment in newSchedule)
            {
                installment.Olb += olbDifference;
                olbDifference += installment.Principal - installment.PaidPrincipal;
                if (!(installment.Principal == installment.PaidPrincipal && installment.Interest == installment.PaidInterest))
                {
                    installment.LastPaymentDate = trancheConfiguration.StartDate;
                }
                installment.Principal = installment.PaidPrincipal;
                installment.Interest = installment.PaidInterest;
            }

            // Adjust the new schedule's installment numbers
            var increment = newSchedule.Count();
            foreach (var installment in trancheSchedule)
            {
                installment.Number += increment;
            }
            var result = new List<IInstallment>();
            result.AddRange(newSchedule);

            // Distribute the overpaid interest
            foreach (var installment in trancheSchedule)
            {
                if (installment.Interest < overpaidInterest)
                {
                    installment.PaidInterest = installment.Interest;
                    overpaidInterest -= installment.Interest;
                }
                else
                {
                    installment.PaidInterest = overpaidInterest;
                    break;
                }
            }

            result.AddRange(trancheSchedule);
            return result;
        }
    }
}
