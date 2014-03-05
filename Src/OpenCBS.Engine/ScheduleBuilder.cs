using System;
using System.Collections.Generic;
using OpenCBS.Engine.InstallmentCalculationPolicy;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class ScheduleBuilder : IScheduleBuilder
    {
        public List<IInstallment> BuildSchedule(IScheduleConfiguration configuration)
        {
            if (configuration.PeriodPolicy == null) throw new ArgumentException("Period policy cannot be null.");
            if (configuration.YearPolicy == null) throw new ArgumentException("Year policy cannot be null.");
            if (configuration.RoundingPolicy == null) throw new ArgumentException("Rounding policy cannot be null.");
            if (configuration.CalculationPolicy == null) throw new ArgumentException("Installment calculation policy cannot be null.");
            if (configuration.AdjustmentPolicy == null) throw new ArgumentException("Adjustment policy cannot be null.");
            if (configuration.DateShiftPolicy == null) throw new ArgumentException("Date shift policy cannot be null.");
            if (configuration.GracePeriod >= configuration.NumberOfInstallments) throw new ArgumentException("Grace period should be less than the number of installments.");

            var installment = BuildFirst(configuration);
            var result = new List<IInstallment> { installment };

            while ((installment = BuildNext(installment, configuration)) != null)
            {
                result.Add(installment);
            }

            configuration.AdjustmentPolicy.Adjust(result, configuration);

            // CalculationPolicy interest during grace period
            if (configuration.ChargeInterestDuringGracePeriod)
            {
                for (var i = 0; i < configuration.GracePeriod; i++)
                {
                    result[i].Interest = CalculateInterest(result[i], configuration);
                }
            }
            // if the difference between start date and first installment date less or greater than period
            result[0].Interest = CalculateFirstInstallmentInterest(result[0], configuration);

            // Initialize RepaymentDate's
            foreach (var i in result)
            {
                i.RepaymentDate = configuration.DateShiftPolicy.ShiftDate(i.EndDate);
            }

            return result;
        }

        private static IInstallment BuildFirst(IScheduleConfiguration configuration)
        {
            var installment = new Installment
            {
                Number = 1,
                StartDate = configuration.StartDate,
                EndDate = configuration.PreferredFirstInstallmentDate,
                Olb = configuration.Amount,
            };
            if (configuration.GracePeriod == 0)
            {
                configuration.CalculationPolicy.Calculate(installment, configuration);
            }

            return installment;
        }

        private static IInstallment BuildNext(IInstallment previous, IScheduleConfiguration configuration)
        {
            if (previous == null) throw new ArgumentException("Previous installment cannot be null.");

            if (previous.Number == configuration.NumberOfInstallments) return null;
            var installment = new Installment
            {
                Number = previous.Number + 1,
                StartDate = previous.EndDate,
                EndDate = configuration.PeriodPolicy.GetNextDate(previous.EndDate),
                Olb = previous.Olb - previous.Principal,
            };
            if (configuration.GracePeriod < installment.Number)
            {
                configuration.CalculationPolicy.Calculate(installment, configuration);
            }
            return installment;
        }

        private static decimal CalculateInterest(IInstallment installment, IScheduleConfiguration configuration)
        {
            var daysInPeriod = configuration.PeriodPolicy.GetNumberOfDays(installment.EndDate);//, configuration.DateShiftPolicy);
            var daysInYear = configuration.YearPolicy.GetNumberOfDays(installment.EndDate);
            var interest = installment.Olb*configuration.InterestRate / 100 * daysInPeriod / daysInYear;
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

        private static decimal CalculateFirstInstallmentInterest(IInstallment installment,
            IScheduleConfiguration configuration)
        {
            var daysInPeriod = configuration.PeriodPolicy.GetNumberOfDays(installment, configuration.DateShiftPolicy);
            var daysInYear = configuration.YearPolicy.GetNumberOfDays(installment.EndDate);
            var interest = installment.Olb * configuration.InterestRate / 100 * daysInPeriod / daysInYear;
            //if schedule is flat
            if (configuration.CalculationPolicy.GetType() == typeof(FlatInstallmentCalculationPolicy))
            {
                var numberOfPeriods =
                    (decimal)
                        (configuration.PeriodPolicy.GetNumberOfPeriodsInYear(
                            configuration.PreferredFirstInstallmentDate, configuration.YearPolicy));
                interest = configuration.Amount * configuration.InterestRate / numberOfPeriods / 100;
            }
            return configuration.RoundingPolicy.Round(interest);
        }
    }
}
