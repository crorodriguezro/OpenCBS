using OpenCBS.ArchitectureV2.Interface.Presenter;

namespace OpenCBS.ArchitectureV2.Interface.View
{
    public interface IBatchRepaymentView : IView<IBatchRepaymentPresenterCallbacks>
    {
        void Run();
    }
}
