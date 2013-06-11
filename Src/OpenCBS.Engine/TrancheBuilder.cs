using System;
using System.Collections.Generic;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class TrancheBuilder : ITrancheBuilder
    {
        public List<IInstallment> BuildTranche(IScheduleBuilder scheduleBuilder, IScheduleConfiguration leftHandConfiguration, IScheduleConfiguration rightHandConfiguration)
        {
            var lhs = scheduleBuilder.BuildSchedule(leftHandConfiguration);
            var rhs = scheduleBuilder.BuildSchedule(rightHandConfiguration);

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

            return result;
        }
    }
}
