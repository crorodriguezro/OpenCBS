
namespace OpenCBS.Engine.Interfaces
{
    public interface ITrancheConfiguration : IBaseScheduleConfiguration
    {
        bool ApplyNewInterestRateToOlb { get; set; }
    }
}
