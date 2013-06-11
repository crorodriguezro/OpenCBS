using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.PeriodPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Monthly")]
    public class MonthlyPeriodPolicy : IPeriodPolicy
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
            return (date - GetPreviousDate(date)).Days;
        }

        public double GetNumberOfPeriodsInYear(DateTime date, IYearPolicy yearPolicy)
        {
            return 12;
        }
    }
}
