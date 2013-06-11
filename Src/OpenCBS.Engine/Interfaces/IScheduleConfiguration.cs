
using System;

namespace OpenCBS.Engine.Interfaces
{
    public interface IScheduleConfiguration
    {
        DateTime StartDate { get; set; }
        DateTime PreferredFirstInstallmentDate { get; set; }
        int NumberOfInstallments { get; set; }
        int GracePeriod { get; set; }
        decimal Amount { get; set; }
        decimal InterestRate { get; set; }

        IPeriodPolicy PeriodPolicy { get; set; }
        IYearPolicy YearPolicy { get; set; }
        IRoundingPolicy RoundingPolicy { get; set; }
        IInstallmentCalculationPolicy CalculationPolicy { get; set; }
        IAdjustmentPolicy AdjustmentPolicy { get; set; }
        IDateShiftPolicy DateShiftPolicy { get; set; }
    }
}
