using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.Extension.Accounting.Model;

namespace OpenCBS.Extension.Accounting.Interface.Presenter
{
    public interface IAccountPresenter : IPresenter
    {
        void Run(Account account = null);
    }
}
