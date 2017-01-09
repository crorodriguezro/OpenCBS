namespace OpenCBS.ArchitectureV2.Accounting.Interface.Presenter
{
    public interface ITurnoverBalancesPresenterCallbacks
    {
        void Refresh();
        void ShowAccountMovements();
        void ShowInExcel();
        void ShowAnalytics();
        void DetachView();
    }
}
