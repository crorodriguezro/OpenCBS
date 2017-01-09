using OpenCBS.ArchitectureV2.Interface.Presenter;

namespace OpenCBS.ArchitectureV2.Accounting.Interface.Presenter
{
    public interface IBookingPresenter : IPresenter
    {
        void Run(int? bookingId = null);
    }
}
