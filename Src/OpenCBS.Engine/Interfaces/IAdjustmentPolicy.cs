using System.Collections.Generic;

namespace OpenCBS.Engine.Interfaces
{
    public interface IAdjustmentPolicy : IPolicy
    {
        void Adjust(List<IInstallment> schedule, IScheduleConfiguration configuration);
    }
}
