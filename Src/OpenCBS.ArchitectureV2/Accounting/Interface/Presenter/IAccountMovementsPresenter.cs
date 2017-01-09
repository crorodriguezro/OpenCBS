using System;
using OpenCBS.ArchitectureV2.Interface.Presenter;

namespace OpenCBS.ArchitectureV2.Accounting.Interface.Presenter
{
    public interface IAccountMovementsPresenter : IPresenter
    {
        void Run();
        void Run(string accountNumber, DateTime from, DateTime to);
    }
}
