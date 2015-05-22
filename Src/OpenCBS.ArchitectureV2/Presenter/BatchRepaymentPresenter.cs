using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.Presenter
{
    public class BatchRepaymentPresenter : IBatchRepaymentPresenter, IBatchRepaymentPresenterCallbacks
    {
        private readonly IBatchRepaymentView _view;

        public BatchRepaymentPresenter(IBatchRepaymentView view)
        {
            _view = view;
        }

        public void Run(int villageBankId)
        {
            _view.Attach(this);
            _view.Run();
        }

        public object View
        {
            get { return _view; }
        }
    }
}
