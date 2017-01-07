using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Interface.Presenter;

namespace OpenCBS.Extension.Accounting.Command
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
