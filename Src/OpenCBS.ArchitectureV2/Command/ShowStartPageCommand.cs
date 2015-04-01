using OpenCBS.ArchitectureV2.CommandData;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Presenter;

namespace OpenCBS.ArchitectureV2.Command
{
    public class ShowStartPageCommand : ICommand<ShowStartPageCommandData>
    {
        private readonly IStartPagePresenter _presenter;

        public ShowStartPageCommand(IStartPagePresenter presenter)
        {
            _presenter = presenter;
        }

        public void Execute(ShowStartPageCommandData commandData)
        {
            _presenter.Run();
        }
    }
}
