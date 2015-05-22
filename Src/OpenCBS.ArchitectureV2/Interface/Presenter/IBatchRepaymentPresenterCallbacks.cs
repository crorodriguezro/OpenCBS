namespace OpenCBS.ArchitectureV2.Interface.Presenter
{
    public interface IBatchRepaymentPresenterCallbacks
    {
        decimal GetDuePrincipal(int loanId);
        decimal GetDueInterest(int loanId);
    }
}
