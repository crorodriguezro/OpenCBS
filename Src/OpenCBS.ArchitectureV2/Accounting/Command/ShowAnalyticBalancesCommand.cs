using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Interface.Presenter;

namespace OpenCBS.Extension.Accounting.Command
{
    public class ShowAnalyticBalancesCommand : ArchitectureV2.Command.Command, ICommand<ShowAnalyticBalancesCommandData>
    {
        private readonly Lazy<IAnalyticBalancesPresenter> _presenter;

        public ShowAnalyticBalancesCommand(Lazy<IAnalyticBalancesPresenter> presenter,
            IApplicationController applicationController)
            : base(applicationController)
        {
            _presenter = presenter;
        }

        public void Execute(ShowAnalyticBalancesCommandData commandData)
        {
            if (commandData.BalancesOnly)
            {
                if (ActivateViewIfExists("AnalyticBalancesWithoutTurnoverView"))
                {
                    return;
                }
            }
            else
            {
                if (ActivateViewIfExists("AnalyticBalancesView"))
                {
                    return;
                }
            }
            _presenter.Value.Run(commandData.Account, commandData.From, commandData.To, commandData.BranchId,
                commandData.BalancesOnly);
        }
    }
}
