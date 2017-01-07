using OpenCBS.ArchitectureV2.Interface.Presenter;

namespace OpenCBS.Extension.Accounting.Interface.Presenter
{
    public interface ITurnoverBalancesPresenter : IPresenter
    {
        void Run(bool balancesOnly = false);
    }
}
