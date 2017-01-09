using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Interface.Presenter;

namespace OpenCBS.ArchitectureV2.Accounting.Interface.Presenter
{
    public interface IAccountPresenter : IPresenter
    {
        void Run(Account account = null);
    }
}
