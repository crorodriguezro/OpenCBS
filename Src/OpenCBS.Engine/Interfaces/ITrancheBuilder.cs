using System.Collections.Generic;

namespace OpenCBS.Engine.Interfaces
{
    public interface ITrancheBuilder
    {
        List<IInstallment> BuildTranche(IScheduleBuilder scheduleBuilder, IScheduleConfiguration oldConfiguration, IScheduleConfiguration newConfiguration);
    }
}
