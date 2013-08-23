using System.Collections.Generic;
using System.Linq;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class RescheduleAssembler
    {
        public IEnumerable<IInstallment> AssembleRescheduling(
            IEnumerable<IInstallment> schedule,
            IScheduleConfiguration rescheduleConfiguration,
            IScheduleBuilder scheduleBuilder)
        {
            // Build a new combined schedule

            // 1. To close all active installments before date of rescheduling.

            // Get the part of the schedule that comes before the rescheduling date...
            var newSchedule =
                from installment in schedule
                where installment.RepaymentDate <= rescheduleConfiguration.StartDate
                select installment;

            // Get overpaid principal = sum of paid principal after the rescheduling date...
            var overpaidPrincipal = (
                from installment in schedule
                where installment.RepaymentDate > rescheduleConfiguration.StartDate
                select installment
            ).Sum(installment => installment.PaidPrincipal);

            //Add overpaid principal to paid principal of the last installment before the rescheduling
            newSchedule.Last().PaidPrincipal += overpaidPrincipal;

            // Close all active installments before date of rescheduling
            var olbDifference = 0m;
            foreach (var installment in newSchedule)
            {
                installment.Olb += olbDifference;
                olbDifference += installment.Principal - installment.PaidPrincipal;
                installment.Principal = installment.PaidPrincipal;
                installment.Interest = installment.PaidInterest;
            }

            // 2. To store amounts of interest paid, those for installments after date of rescheduling.
            var overpaidInterest = (
                from installment in schedule
                where installment.RepaymentDate > rescheduleConfiguration.StartDate
                select installment
            ).Sum(installment => installment.PaidInterest);

            // 3. To calculate extra interest for used days. We check the date of rescheduling and OLB we have on it. 
            //    We need it to calculate extra interest between last closed installment and date of rescheduling. 

            var currentOlb = newSchedule.Last().Olb - newSchedule.Last().PaidPrincipal;
            var daysInYear = rescheduleConfiguration.YearPolicy.GetNumberOfDays(rescheduleConfiguration.StartDate);
            var usedDays = (rescheduleConfiguration.StartDate - newSchedule.Last().RepaymentDate).Days;
            var extraInterest = currentOlb * rescheduleConfiguration.InterestRate / 100 * usedDays / daysInYear;

            // 4. We generate new schedule according to new parametrs.
            rescheduleConfiguration.Amount = currentOlb;
            var rescheduled = scheduleBuilder.BuildSchedule(rescheduleConfiguration);

            // Adjust the new schedule's installment numbers
            var increment = newSchedule.Count();
            foreach (var installment in rescheduled)
            {
                installment.Number += increment;
            }

            // Distribute the extra and overpaid interest
            rescheduled.First().Interest += extraInterest;
            foreach (var installment in rescheduled)
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

            var result = new List<IInstallment>();
            result.AddRange(newSchedule);
            result.AddRange(rescheduled);

            return result;
        }
    }
}
