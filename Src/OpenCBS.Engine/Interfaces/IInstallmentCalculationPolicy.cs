
namespace OpenCBS.Engine.Interfaces
{
    public interface IInstallmentCalculationPolicy : IPolicy
    {
        void Calculate(IInstallment installment, IScheduleConfiguration configuration);
    }
}
