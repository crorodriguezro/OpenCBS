namespace OpenCBS.Extension.Accounting.Interface.Presenter
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
