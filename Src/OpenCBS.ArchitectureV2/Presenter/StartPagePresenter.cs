using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.ArchitectureV2.Message;
using TinyMessenger;

namespace OpenCBS.ArchitectureV2.Presenter
{
    public class StartPagePresenter : IStartPagePresenter, IStartPagePresenterCallbacks
    {
        private readonly IStartPageView _view;
        private readonly ITinyMessengerHub _messengerHub;

        public StartPagePresenter(IStartPageView view, ITinyMessengerHub messengerHub)
        {
            _view = view;
            _messengerHub = messengerHub;
        }

        public void Run()
        {
            _view.Attach(this);
            _messengerHub.Publish(new ShowViewMessage(this, _view));
        }

        public object View
        {
            get { return _view; }
        }
    }
}
