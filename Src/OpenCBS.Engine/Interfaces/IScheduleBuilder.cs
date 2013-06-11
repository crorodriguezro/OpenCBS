using System.Collections.Generic;

namespace OpenCBS.Engine.Interfaces
{
    public interface IScheduleBuilder
    {
        List<IInstallment> BuildSchedule();
    }
}
