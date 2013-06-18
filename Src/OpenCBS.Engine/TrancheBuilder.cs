using System;
using System.Collections.Generic;
using System.Linq;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class TrancheBuilder : ITrancheBuilder
    {
        private DateTime GetLastEndDate(IEnumerable<IInstallment> schedule, ITrancheConfiguration trancheConfiguration)
        {
            var installment = (from i in schedule
                               where i.RepaymentDate <= trancheConfiguration.StartDate
                               select i).LastOrDefault();
            if (installment == null) return schedule.First().StartDate;
            return installment.RepaymentDate;
        }

        private decimal GetExtraInterest(IEnumerable<IInstallment> schedule,
                                         IScheduleConfiguration scheduleConfiguration,
                                         ITrancheConfiguration trancheConfiguration)
        {
            var days = (trancheConfiguration.StartDate - GetLastEndDate(schedule, trancheConfiguration)).Days;
            var daysInYear = scheduleConfiguration.YearPolicy.GetNumberOfDays(trancheConfiguration.StartDate);
            var olb = schedule.Sum(i => i.Principal - i.PaidPrincipal);
            var interest = olb * scheduleConfiguration.InterestRate / 100 * days / daysInYear;
            return scheduleConfiguration.RoundingPolicy.Round(interest);
        }

        public List<IInstallment> BuildTranche(IEnumerable<IInstallment> schedule, IScheduleBuilder scheduleBuilder, IScheduleConfiguration scheduleConfiguration, ITrancheConfiguration trancheConfiguration)
        {
            var rhc = (IScheduleConfiguration)scheduleConfiguration.Clone();
            rhc.Amount = trancheConfiguration.Amount;
            rhc.NumberOfInstallments = trancheConfiguration.NumberOfInstallments;
            rhc.GracePeriod = trancheConfiguration.GracePeriod;
            rhc.InterestRate = trancheConfiguration.InterestRate;
            rhc.StartDate = trancheConfiguration.StartDate;
            rhc.PreferredFirstInstallmentDate = trancheConfiguration.PreferredFirstInstallmentDate;

            var lhc = (IScheduleConfiguration)rhc.Clone();
            lhc.Amount = schedule.Sum(i => i.Principal - i.PaidPrincipal);
            if (!trancheConfiguration.ApplyNewInterestRateToOlb)
            {
                lhc.InterestRate = scheduleConfiguration.InterestRate;
            }

            var lhs = scheduleBuilder.BuildSchedule(lhc);
            var rhs = scheduleBuilder.BuildSchedule(rhc);

            var result = new List<IInstallment>();

            // Merge the two schedules
            var max = Math.Max(lhs.Count, rhs.Count);
            for (var i = 0; i < max; i++)
            {
                var lhi = i >= lhs.Count ? null : lhs[i];
                var rhi = i >= rhs.Count ? null : rhs[i];

                IInstallment installment;

                if (lhi == null)
                {
                    installment = rhi;
                }
                else if (rhi == null)
                {
                    installment = lhi;
                }
                else
                {
                    installment = new Installment
                    {
                        Number = lhi.Number,
                        StartDate = lhi.StartDate,
                        EndDate = lhi.EndDate,
                        RepaymentDate = lhi.RepaymentDate,
                        Principal = lhi.Principal + rhi.Principal,
                        Interest = lhi.Interest + rhi.Interest,
                        Olb = lhi.Olb + rhi.Olb,
                    };
                }
                result.Add(installment);
            }

            result[0].Interest += GetExtraInterest(schedule, scheduleConfiguration, trancheConfiguration);
            return result;
        }
    }
}
