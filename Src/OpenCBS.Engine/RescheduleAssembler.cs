using System.Collections.Generic;
using System.Linq;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class RescheduleAssembler
    {
        public IEnumerable<IInstallment> AssembleRescheduling(
            IEnumerable<IInstallment> schedule,
            IScheduleConfiguration scheduleConfiguration,
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
            if (newSchedule.Any())
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


            // 3. To get total of first calculated interest. It will be interest between last closed installment and date of rescheduling 
	        //    plus interest between date of rescheduling and first repayment date

            //    To calculate extra interest for used days.
            //    For the case when date of rescheduling < date of first installment
            var currentOlb = schedule.First().Olb;
            var usedDays = 0;
            if (newSchedule.Any())
            {
                currentOlb = newSchedule.Last().Olb - newSchedule.Last().PaidPrincipal;
                usedDays = (rescheduleConfiguration.StartDate - newSchedule.Last().EndDate).Days;
            }
            var daysInYear = scheduleConfiguration.YearPolicy.GetNumberOfDays(rescheduleConfiguration.StartDate);
            var extraInterest = currentOlb*scheduleConfiguration.InterestRate/100*usedDays/daysInYear;

            // To calculate interest between date of rescheduling and first repayment date.
            var daysTillRepayment =
                (rescheduleConfiguration.PreferredFirstInstallmentDate - rescheduleConfiguration.StartDate).Days;
            var firstInterest = currentOlb * rescheduleConfiguration.InterestRate / 100 * daysTillRepayment / daysInYear;

            // 4. We generate new schedule according to new parametrs.
            rescheduleConfiguration.Amount = currentOlb;
            rescheduleConfiguration.AdjustmentPolicy = scheduleConfiguration.AdjustmentPolicy;
            rescheduleConfiguration.CalculationPolicy = scheduleConfiguration.CalculationPolicy;
            rescheduleConfiguration.DateShiftPolicy = scheduleConfiguration.DateShiftPolicy;
            rescheduleConfiguration.PeriodPolicy = scheduleConfiguration.PeriodPolicy;
            rescheduleConfiguration.RoundingPolicy = scheduleConfiguration.RoundingPolicy;
            rescheduleConfiguration.YearPolicy = scheduleConfiguration.YearPolicy;
            var rescheduled = scheduleBuilder.BuildSchedule(rescheduleConfiguration);

            // Adjust the new schedule's installment numbers
            var increment = newSchedule.Count();
            foreach (var installment in rescheduled)
            {
                installment.Number += increment;
            }

            // Distribute the extra and overpaid interest
            rescheduled.First().Interest = rescheduleConfiguration.RoundingPolicy.Round(firstInterest + extraInterest);
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
