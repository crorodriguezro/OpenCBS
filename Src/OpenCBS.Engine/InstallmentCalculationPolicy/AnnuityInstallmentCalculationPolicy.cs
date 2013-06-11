using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.InstallmentCalculationPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Annuity")]
    public class AnnuityInstallmentCalculationPolicy : BaseInstallmentCalculationPolicy, IInstallmentCalculationPolicy
    {
        public void Calculate(IInstallment installment, IScheduleConfiguration configuration)
        {
            var number = configuration.NumberOfInstallments - configuration.GracePeriod;
            var numberOfPeriods = configuration.PeriodPolicy.GetNumberOfPeriodsInYear(installment.EndDate, configuration.YearPolicy);
            var interestRate = (double)configuration.InterestRate / 100 / numberOfPeriods;

            var numerator = interestRate * (double)configuration.Amount;
            var denominator = 1 - 1 / Math.Pow(1 + interestRate, number);
            var total = configuration.RoundingPolicy.Round((decimal)(numerator / denominator));

            installment.Interest = CalculateInterest(installment, configuration, installment.Olb);
            installment.Principal = total - installment.Interest;
        }
    }
}
