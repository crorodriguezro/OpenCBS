using System;
using NUnit.Framework;
using OpenCBS.Engine.PeriodPolicy;
using OpenCBS.Engine.YearPolicy;

namespace OpenCBS.Engine.Test
{
    [TestFixture]
    public class PeriodPolicy
    {
        [Test]
        public void DailyPeriodPolicy_GetNextDate_ReturnsNextDay()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new DailyPeriodPolicy();
            Assert.That(policy.GetNextDate(date), Is.EqualTo(new DateTime(2013, 6, 8)));
        }

        [Test]
        public void DailyPeriodPolicy_GetPreviousDate_ReturnsPreviousDay()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new DailyPeriodPolicy();
            Assert.That(policy.GetPreviousDate(date), Is.EqualTo(new DateTime(2013, 6, 6)));
        }

        [Test]
        public void DailyPeriodPolicy_GetNumberOfDays_ReturnsOne()
        {
            var date = DateTime.Today;
            var policy = new DailyPeriodPolicy();
            Assert.That(policy.GetNumberOfDays(date), Is.EqualTo(1));
        }

        [Test]
        public void DailyPeriodPolicy_GetNumberOfPeriodsInYear_ReturnsActualNumberOfDays()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new DailyPeriodPolicy();
            var yearPolicy = new ActualNumberOfDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(365));
            date = new DateTime(2012, 6, 7);
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(366));
        }

        [Test]
        public void DailyPeriodPolicy_GetNumberOfPeriodsInYear_Returns360()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new DailyPeriodPolicy();
            var yearPolicy = new ThreeHundredSixtyDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(360));
        }

        [Test]
        public void DailyPeriodPolicy_GetNumberOfPeriodsInYear_Returns365()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new DailyPeriodPolicy();
            var yearPolicy = new ThreeHundredSixtyFiveDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(365));
            date = new DateTime(2012, 6, 7);
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(365));
        }

        [Test]
        public void MonthlyPeriodPolicy_GetNextDate_ReturnsNextMonth()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new MonthlyPeriodPolicy();
            Assert.That(policy.GetNextDate(date), Is.EqualTo(new DateTime(2013, 7, 7)));
        }

        [Test]
        public void MonthlyPeriodPolicy_GetPreviousDate_ReturnsPreviousMonth()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new MonthlyPeriodPolicy();
            Assert.That(policy.GetPreviousDate(date), Is.EqualTo(new DateTime(2013, 5, 7)));
        }

        [Test]
        public void MonthlyPeriodPolicy_GetNumberOfDays_ReturnsActualNumberOfDays()
        {
            var date1 = new DateTime(2013, 2, 1);
            var date2 = new DateTime(2013, 3, 1);
            var date3 = new DateTime(2013, 4, 1);
            var date4 = new DateTime(2013, 5, 1);
            var policy = new MonthlyPeriodPolicy();
            Assert.That(policy.GetNumberOfDays(date1), Is.EqualTo(31));
            Assert.That(policy.GetNumberOfDays(date2), Is.EqualTo(28));
            Assert.That(policy.GetNumberOfDays(date3), Is.EqualTo(31));
            Assert.That(policy.GetNumberOfDays(date4), Is.EqualTo(30));
        }

        [Test]
        public void MonthlyPeriodPolicy_GetNumberOfPeriodsInYear_Returns12()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new MonthlyPeriodPolicy();
            var yearPolicy = new ActualNumberOfDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(12));
        }

        [Test]
        public void Monthly30DayPeriodPolicy_GetNextDate_ReturnsNextMonth()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new Monthly30DayPeriodPolicy();
            Assert.That(policy.GetNextDate(date), Is.EqualTo(new DateTime(2013, 7, 7)));
        }

        [Test]
        public void Monthly30DayPeriodPolicy_GetPreviousDate_ReturnsPreviousMonth()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new Monthly30DayPeriodPolicy();
            Assert.That(policy.GetPreviousDate(date), Is.EqualTo(new DateTime(2013, 5, 7)));
        }

        [Test]
        public void Monthly30DayPeriodPolicy_GetNumberOfDays_Returns30()
        {
            var date1 = new DateTime(2013, 2, 1);
            var date2 = new DateTime(2013, 3, 1);
            var date3 = new DateTime(2013, 4, 1);
            var date4 = new DateTime(2013, 5, 1);
            var policy = new Monthly30DayPeriodPolicy();
            Assert.That(policy.GetNumberOfDays(date1), Is.EqualTo(30));
            Assert.That(policy.GetNumberOfDays(date2), Is.EqualTo(30));
            Assert.That(policy.GetNumberOfDays(date3), Is.EqualTo(30));
            Assert.That(policy.GetNumberOfDays(date4), Is.EqualTo(30));
        }

        [Test]
        public void Monthly30DayPeriodPolicy_GetNumberOfPeriodsInYear_Returns12()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new Monthly30DayPeriodPolicy();
            var yearPolicy = new ActualNumberOfDayYearPolicy();
            Assert.That(policy.GetNumberOfPeriodsInYear(date, yearPolicy), Is.EqualTo(12));
        }
    }
}
