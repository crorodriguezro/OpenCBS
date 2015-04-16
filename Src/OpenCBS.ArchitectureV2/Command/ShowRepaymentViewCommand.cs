using System.Windows.Forms;
using OpenCBS.ArchitectureV2.CommandData;
using OpenCBS.ArchitectureV2.Event;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Presenter;

namespace OpenCBS.ArchitectureV2.Command
{
    public class ShowRepaymentViewCommand : ICommand<ShowRepaymentViewCommandData>
    {
        private readonly IRepaymentPresenter _presenter;
        private readonly IApplicationController _appController;

        public ShowRepaymentViewCommand(IRepaymentPresenter presenter, IApplicationController appController)
        {
            _presenter = presenter;
            _appController = appController;
        }

        public void Execute(ShowRepaymentViewCommandData commandData)
        {
            var result = _presenter.Run(commandData.Loan);
            if (result == DialogResult.OK)
            {
                _appController.Publish(new RepaymentNotification(this, commandData.Loan.Id));
            }
        }
    }
}
