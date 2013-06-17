
using System.Collections.Generic;
using System.Linq;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.AdjustmentPolicy
{
    public abstract class BaseAdjustmentPolicy
    {
        public decimal GetAdjustment(List<IInstallment> schedule, IScheduleConfiguration configuration)
        {
            return configuration.Amount - schedule.Sum(i => i.Principal);
        }
    }
}
