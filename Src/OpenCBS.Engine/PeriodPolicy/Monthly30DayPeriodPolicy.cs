using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.PeriodPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Monthly (30 day)")]
    public class Monthly30DayPeriodPolicy : IPeriodPolicy
    {
        public DateTime GetNextDate(DateTime date)
        {
            return date.AddMonths(1);
        }

        public DateTime GetPreviousDate(DateTime date)
        {
            return date.AddMonths(-1);
        }

        public int GetNumberOfDays(DateTime date)
        {
            return 30;
        }

        public double GetNumberOfPeriodsInYear(DateTime date, IYearPolicy yearPolicy)
        {
            return 12;
        }
    }
}
