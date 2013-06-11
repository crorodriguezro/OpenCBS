using System;
using System.Collections.Generic;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine
{
    public class ScheduleBuilder : IScheduleBuilder
    {
        private readonly IScheduleConfiguration _configuration;

        public ScheduleBuilder(IScheduleConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<IInstallment> BuildSchedule()
        {
            if (_configuration.PeriodPolicy == null) throw new ArgumentException("Period policy cannot be null.");
            if (_configuration.YearPolicy == null) throw new ArgumentException("Year policy cannot be null.");
            if (_configuration.RoundingPolicy == null) throw new ArgumentException("Rounding policy cannot be null.");
            if (_configuration.CalculationPolicy == null) throw new ArgumentException("Installment calculation policy cannot be null.");
            if (_configuration.AdjustmentPolicy == null) throw new ArgumentException("Adjustment policy cannot be null.");
            if (_configuration.DateShiftPolicy == null) throw new ArgumentException("Date shift policy cannot be null.");
            if (_configuration.GracePeriod >= _configuration.NumberOfInstallments) throw new ArgumentException("Grace period should be less than the number of installments.");

            var installment = BuildFirst();
            var result = new List<IInstallment> { installment };

            while ((installment = BuildNext(installment)) != null)
            {
                result.Add(installment);
            }

            _configuration.AdjustmentPolicy.Adjust(result, _configuration);

            // CalculationPolicy interest during grace period
            for (var i = 0; i < _configuration.GracePeriod; i++)
            {
                result[i].Interest = CalculateInterest(result[i]);
            }

            // Caluclate interest of the first installment if the maturity
            // is less than or greater than a period (week, month, etc.)
            var firstInstallment = result[0];
            var periodEndDate = _configuration.PeriodPolicy.GetNextDate(firstInstallment.StartDate);
            var actualEndDate = firstInstallment.EndDate;
            if (periodEndDate != actualEndDate)
            {
                var difference = (actualEndDate - periodEndDate).Days;
                var daysInYear = _configuration.YearPolicy.GetNumberOfDays(firstInstallment.EndDate);
                var interest = firstInstallment.Olb * _configuration.InterestRate * difference / daysInYear;
                firstInstallment.Interest += _configuration.RoundingPolicy.Round(interest);
            }

            // Initialize RepaymentDate's
            foreach (var i in result)
            {
                i.RepaymentDate = _configuration.DateShiftPolicy.ShiftDate(i.EndDate);
            }

            return result;
        }

        private IInstallment BuildFirst()
        {
            var installment = new Installment
            {
                Number = 1,
                StartDate = _configuration.StartDate,
                EndDate = _configuration.PreferredFirstInstallmentDate,
                Olb = _configuration.Amount,
            };
            if (_configuration.GracePeriod == 0)
            {
                _configuration.CalculationPolicy.Calculate(installment, _configuration);
            }

            return installment;
        }

        private IInstallment BuildNext(IInstallment previous)
        {
            if (previous == null) throw new ArgumentException("Previous installment cannot be null.");

            if (previous.Number == _configuration.NumberOfInstallments) return null;
            var installment = new Installment
            {
                Number = previous.Number + 1,
                StartDate = previous.EndDate,
                EndDate = _configuration.PeriodPolicy.GetNextDate(previous.EndDate),
                Olb = previous.Olb - previous.Principal,
            };
            if (_configuration.GracePeriod < installment.Number)
            {
                _configuration.CalculationPolicy.Calculate(installment, _configuration);
            }
            return installment;
        }

        private decimal CalculateInterest(IInstallment installment)
        {
            var daysInPeriod = _configuration.PeriodPolicy.GetNumberOfDays(installment.EndDate);
            var daysInYear = _configuration.YearPolicy.GetNumberOfDays(installment.EndDate);
            var interest = installment.Olb * _configuration.InterestRate / 100 * daysInPeriod / daysInYear;
            return _configuration.RoundingPolicy.Round(interest);
        }
    }
}
