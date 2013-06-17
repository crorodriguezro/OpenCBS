using System.Collections.Generic;

namespace OpenCBS.Engine.Interfaces
{
    public interface ITrancheBuilder
    {
        List<IInstallment> BuildTranche(IEnumerable<IInstallment> schedule, IScheduleBuilder scheduleBuilder, IScheduleConfiguration scheduleConfiguration, ITrancheConfiguration trancheConfiguration);
    }
}
