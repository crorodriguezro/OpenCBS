using System;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.PeriodPolicy
{
    public class CustomPeriodPolicy : IPeriodPolicy
    {
        private readonly int _numberOfDays;

        public CustomPeriodPolicy(int numberOfDays)
        {
            _numberOfDays = numberOfDays;
        }

        public DateTime GetNextDate(DateTime date)
        {
            return date.AddDays(_numberOfDays);
        }

        public DateTime GetPreviousDate(DateTime date)
        {
            return date.AddDays(-_numberOfDays);
        }

        public int GetNumberOfDays(DateTime date)
        {
            return _numberOfDays;
        }

        public double GetNumberOfPeriodsInYear(DateTime date, IYearPolicy yearPolicy)
        {
            return (double) yearPolicy.GetNumberOfDays(date) / _numberOfDays;
        }
    }
}
