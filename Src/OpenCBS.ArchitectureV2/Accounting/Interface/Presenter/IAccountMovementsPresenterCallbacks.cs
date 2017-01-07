namespace OpenCBS.Extension.Accounting.Interface.Presenter
{
    public interface IAccountMovementsPresenterCallbacks
    {
        void Refresh();
        void ShowInExcel();
        void DetachView();
    }
}
