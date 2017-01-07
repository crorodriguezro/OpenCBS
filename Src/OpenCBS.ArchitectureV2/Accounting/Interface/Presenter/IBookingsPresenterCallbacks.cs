namespace OpenCBS.Extension.Accounting.Interface.Presenter
{
    public interface IBookingsPresenterCallbacks
    {
        void OnCheck();
        void Add();
        void Edit();
        void OnDeleteBooking();
        void OnPrint(object report);
        void Refresh();
        void OnFiltering();
        void OnControlPrint();
        void DetachView();
    }
}
