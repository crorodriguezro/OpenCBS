using System.Collections.Generic;
using System.Linq;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.AdjustmentPolicy
{
    public abstract class BaseAdjustmentPolicy
    {
        public decimal GetAdjustment(List<Installment> schedule, IScheduleConfiguration configuration)
        {
            return configuration.Amount - schedule.Sum(i => i.CapitalRepayment.Value);
        }

        public decimal GetAdjustmentInterestRepayment(List<Installment> schedule, IScheduleConfiguration configuration)
        {
            var numberOfPeriods =
                (decimal)
                    (configuration.PeriodPolicy.GetNumberOfPeriodsInYear(configuration.PreferredFirstInstallmentDate,
                        configuration.YearPolicy));
            return
                configuration.RoundingPolicy.Round((configuration.Amount*configuration.InterestRate/numberOfPeriods/100)*
                                                   configuration.NumberOfInstallments) -
                schedule.Sum(i => i.InterestsRepayment.Value);
        }
    }
}
