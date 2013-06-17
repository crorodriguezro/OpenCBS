using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.PeriodPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Daily")]
    public class DailyPeriodPolicy : IPeriodPolicy
    {
        public DateTime GetNextDate(DateTime date)
        {
            return date.AddDays(1);
        }

        public DateTime GetPreviousDate(DateTime date)
        {
            return date.AddDays(-1);
        }

        public int GetNumberOfDays(DateTime date)
        {
            return 1;
        }

        public double GetNumberOfPeriodsInYear(DateTime date, IYearPolicy yearPolicy)
        {
            return yearPolicy.GetNumberOfDays(date);
        }
    }
}
