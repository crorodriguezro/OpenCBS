using System.Collections.Generic;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.AdjustmentPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "First installment")]
    public class FirstInstallmentAdjustmentPolicy : BaseAdjustmentPolicy, IAdjustmentPolicy
    {
        public void Adjust(List<IInstallment> schedule, IScheduleConfiguration configuration)
        {
            schedule[configuration.GracePeriod].Principal += GetAdjustment(schedule, configuration);
            for (var i = configuration.GracePeriod + 1; i < schedule.Count; i++)
            {
                schedule[i].Olb = schedule[i - 1].Olb - schedule[i - 1].Principal;
            }
        }
    }
}
