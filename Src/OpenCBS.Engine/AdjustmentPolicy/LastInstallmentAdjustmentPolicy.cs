using System.Collections.Generic;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.AdjustmentPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Last installment")]
    public class LastInstallmentAdjustmentPolicy : BaseAdjustmentPolicy, IAdjustmentPolicy
    {
        public void Adjust(List<IInstallment> schedule, IScheduleConfiguration configuration)
        {
            schedule[schedule.Count - 1].Principal += GetAdjustment(schedule, configuration);
        }
    }
}
