namespace OpenCBS.ArchitectureV2.Accounting.Interface.Presenter
{
    public interface IAccountMovementsPresenterCallbacks
    {
        void Refresh();
        void ShowInExcel();
        void DetachView();
    }
}
