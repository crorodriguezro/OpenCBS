using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Repository;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.ArchitectureV2.Message;

namespace OpenCBS.ArchitectureV2.Presenter
{
    public class VillageBankPresenter : IVillageBankPresenter, IVillageBankPresenterCallbacks
    {
        private readonly IVillageBankView _view;
        private readonly IApplicationController _applicationController;
        private readonly IVillageBankRepository _villageBankRepository;

        public VillageBankPresenter(
            IVillageBankView view,
            IApplicationController applicationController,
            IVillageBankRepository villageBankRepository)
        {
            _view = view;
            _applicationController = applicationController;
            _villageBankRepository = villageBankRepository;
        }

        public void Run(int villageBankId)
        {
            _view.Attach(this);
            _applicationController.Publish(new ShowViewMessage(this, _view));
            _view.SetVillageBank(_villageBankRepository.Get(villageBankId));
        }

        public object View
        {
            get { return _view; }
        }
    }
}
