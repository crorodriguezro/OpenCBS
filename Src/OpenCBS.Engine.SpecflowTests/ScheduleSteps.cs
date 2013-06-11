using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NUnit.Framework;
using OpenCBS.Engine;
using OpenCBS.Engine.Interfaces;
using TechTalk.SpecFlow;

namespace OpenCBS.Specflow.Test
{
    public static class TableTools
    {
        public static T Get<T>(this Table table, string key)
        {
            var russianCultureInfo = new CultureInfo("ru-RU");
            var value = (
                from row in table.Rows
                where row["Name"] == key
                select row["Value"]
            ).FirstOrDefault();
            if (null == value) return default(T);

            if (typeof (string) == typeof (T))
            {
                return (T)(object)value;
            }

            if (typeof(int) == typeof(T))
            {
                return (T)(object)int.Parse(value, russianCultureInfo);
            }

            if (typeof(decimal) == typeof(T))
            {
                return (T)(object)decimal.Parse(value, russianCultureInfo);
            }

            if (typeof(DateTime) == typeof(T))
            {
                return (T)(object)DateTime.Parse(value, russianCultureInfo, DateTimeStyles.AssumeLocal);
            }

            if (typeof(T) == typeof(bool))
            {
                return (T)(object)("Yes" == value);
            }

            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), value);
            }

            return default(T);
        }
    }

    [Binding]
    public class ScheduleSteps
    {
        private IScheduleConfiguration _configuration;
        private List<IInstallment> _schedule;

        [Given(@"this configuration")]
        public void GivenThisConfiguration(Table table)
        {
            var factory = new DefaultScheduleConfigurationFactory();
            _configuration = factory
                .Init()
                .With(table.Get<string>("Type")).CalculationPolicy()
                .With(table.Get<string>("Payments")).PeriodPolicy()
                .With(table.Get<string>("Year")).YearPolicy()
                .With(table.Get<string>("Rounding")).RoundingPolicy()
                .With(table.Get<string>("Adjustment")).AdjustmentPolicy()
                .With(table.Get<string>("Date shift")).DateShiftPolicy()
                .With(table.Get<string>("Installments")).Installments()
                .With(table.Get<string>("Grace period")).GracePeriod()
                .With(table.Get<string>("Amount")).Amount()
                .With(table.Get<string>("Interest rate")).InterestRate()
                .With(table.Get<string>("Start on")).StartDate()
                .With(table.Get<string>("First repayment on")).FirstRepaymentDate()
                .GetConfiguration();
        }
        
        [When(@"I create a schedule")]
        public void WhenICreateASchedule()
        {
            var scheduleBuilder = new ScheduleBuilder();
            _schedule = scheduleBuilder.BuildSchedule(_configuration);
        }
        
        [Then(@"the schedule is")]
        public void ThenTheScheduleIs(Table table)
        {
            var cultureInfo = new CultureInfo("ru-RU");
            foreach (var row in table.Rows)
            {
                var installmentNumber = int.Parse(row["Number"]);
                var installment = _schedule[installmentNumber - 1];
                Assert.That(installment.Number, Is.EqualTo(installmentNumber));

                var startDate = DateTime.Parse(row["Start date"], cultureInfo, DateTimeStyles.AssumeLocal);
                Assert.That(installment.StartDate, Is.EqualTo(startDate));

                var endDate = DateTime.Parse(row["End date"], cultureInfo, DateTimeStyles.AssumeLocal);
                Assert.That(installment.EndDate, Is.EqualTo(endDate));

                var repaymentDate = DateTime.Parse(row["Repayment date"], cultureInfo, DateTimeStyles.AssumeLocal);
                Assert.That(installment.RepaymentDate, Is.EqualTo(repaymentDate));

                var principal = decimal.Parse(row["Principal"], cultureInfo);
                Assert.That(installment.Principal, Is.EqualTo(principal));

                var interest = decimal.Parse(row["Interest"], cultureInfo);
                Assert.That(installment.Interest, Is.EqualTo(interest));

                var olb = decimal.Parse(row["Olb"], cultureInfo);
                Assert.That(installment.Olb, Is.EqualTo(olb));
            }
        }
    }
}
