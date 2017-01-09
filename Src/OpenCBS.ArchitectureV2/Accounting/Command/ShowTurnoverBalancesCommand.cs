using System;
using OpenCBS.ArchitectureV2.Accounting.CommandData;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface;

namespace OpenCBS.ArchitectureV2.Accounting.Command
{
    public class ShowTurnoverBalancesCommand : ArchitectureV2.Command.Command, ICommand<ShowTurnoverBalancesCommandData>
    {
        private readonly Lazy<ITurnoverBalancesPresenter> _presenter;

        public ShowTurnoverBalancesCommand(Lazy<ITurnoverBalancesPresenter> presenter, IApplicationController applicationController)
            : base(applicationController)
        {
            _presenter = presenter;
        }

        public void Execute(ShowTurnoverBalancesCommandData commandData)
        {
            if (commandData.BalancesOnly)
            {
                if (ActivateViewIfExists("BalancesView"))
                {
                    return;
                }
            }
            else
            {
                if (ActivateViewIfExists("TurnoverBalancesView"))
                {
                    return;
                }
            }
            _presenter.Value.Run(commandData.BalancesOnly);
        }
    }
}
