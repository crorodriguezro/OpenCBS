using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.InstallmentCalculationPolicy
{
    public class BaseInstallmentCalculationPolicy
    {
        protected decimal CalculateInterest(IInstallment installment, IScheduleConfiguration configuration, decimal amount)
        {
            var daysInPeriod = configuration.PeriodPolicy.GetNumberOfDays(installment.EndDate);
            var daysInYear = configuration.YearPolicy.GetNumberOfDays(installment.EndDate);
            var interest = amount * configuration.InterestRate / 100 * daysInPeriod / daysInYear;
            return configuration.RoundingPolicy.Round(interest);
        }
    }
}
