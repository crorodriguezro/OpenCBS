using System;
using System.Linq.Expressions;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.InstallmentCalculationPolicy
{
    public class BaseInstallmentCalculationPolicy
    {
        protected decimal CalculateInterest(IInstallment installment, IScheduleConfiguration configuration, decimal amount)
        {
            var daysInPeriod = configuration.PeriodPolicy.GetNumberOfDays(installment.EndDate);//, configuration.DateShiftPolicy);
            var daysInYear = configuration.YearPolicy.GetNumberOfDays(installment.EndDate);
            var interest = installment.Olb * configuration.InterestRate / 100 * daysInPeriod / daysInYear;
            //if schedule is flat
            if (configuration.CalculationPolicy.GetType() == typeof(FlatInstallmentCalculationPolicy))
            {
                var numberOfPeriods =
                    (decimal)
                        (configuration.PeriodPolicy.GetNumberOfPeriodsInYear(
                            configuration.PreferredFirstInstallmentDate, configuration.YearPolicy));
                interest = configuration.Amount*configuration.InterestRate/numberOfPeriods/100;
            }
            return configuration.RoundingPolicy.Round(interest);
        }
    }
}
