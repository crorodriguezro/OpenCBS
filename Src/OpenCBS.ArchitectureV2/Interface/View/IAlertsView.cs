using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Model;

namespace OpenCBS.ArchitectureV2.Interface.View
{
    public interface IAlertsView : IView<IAlertsPresenterCallbacks>
    {
        void SetAlerts(List<Alert> alerts);
        void StartProgress();
        void StopProgress();

        bool ShowPerformingLoans { get; }
        bool ShowLateLoans { get; }
        bool ShowPendingLoans { get; }
        bool ShowValidatedLoans { get; }
        bool ShowPostponedLoans { get; }
        bool ShowPendingSavings { get; }
        bool ShowOverdraftSavings { get; }
    }
}
