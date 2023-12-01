using CongestionTax.Core;
using CongestionTax.Core.Dtos;
using CongestionTax.Core.Entities;
using CongestionTax.Core.RuleEngine;

namespace CongestionTax.Service
{
    public class TimeTableChargeRule : ICongestionTaxRule
    {
        private static readonly List<TimeTableRow> _timeTable = new()
                                                { new TimeTableRow(new TimeSpan(6,0,0),new TimeSpan(6,29,0),8m),
                                                  new TimeTableRow(new TimeSpan(6,30,0),new TimeSpan(6,59,0),13m),
                                                  new TimeTableRow(new TimeSpan(7,0,0),new TimeSpan(7,59,0),18m),
                                                  new TimeTableRow(new TimeSpan(8,0,0),new TimeSpan(8,29,0),13m),
                                                  new TimeTableRow(new TimeSpan(8,30,0),new TimeSpan(14,59,0),8m),
                                                  new TimeTableRow(new TimeSpan(15,0,0),new TimeSpan(15,29,0),13m),
                                                  new TimeTableRow(new TimeSpan(15,30,0),new TimeSpan(16,59,0),18),
                                                  new TimeTableRow(new TimeSpan(17,0,0),new TimeSpan(17,59,0),13),
                                                  new TimeTableRow(new TimeSpan(18,0,0),new TimeSpan(18,29,0),8),
                                                  new TimeTableRow(new TimeSpan(18,30,0),new TimeSpan(23,59,0),0),
                                                  new TimeTableRow(new TimeSpan(0,0,0),new TimeSpan(5,59,0),0)
        };
        int Priority => 3;

        public async Task<EvalutionResult> Evaluate(Travel travel, EvalutionResult lastEvalutionResult)
        {
            var continueEvalution = true;

            var amount = _timeTable.FirstOrDefault(t => t.FromTime <= travel.TravelAt.TimeOfDay
                                                    && t.ToTime >= travel.TravelAt.TimeOfDay).Toll;

            if (amount == 0) { continueEvalution = false; }

            return new EvalutionResult(continueEvalution, amount);
        }

    }
    public readonly struct TimeTableRow
    {
        public TimeSpan FromTime { get; }
        public TimeSpan ToTime { get; }
        public decimal Toll { get; }
        public TimeTableRow(TimeSpan fromDate, TimeSpan toDate, decimal tollCharge)
        {
            (FromTime, ToTime, Toll) = (fromDate, toDate, tollCharge);
        }
    }



}
