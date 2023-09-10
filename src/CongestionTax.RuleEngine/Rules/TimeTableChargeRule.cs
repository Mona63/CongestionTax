using System;

namespace CongestionTax.RuleEngine
{
    public class TimeTableChargeRule : ICaculationTollRule
    {
        public int Proiority { get; set; }
        //Free Time Charge Is Applied In Free Rules
        private static readonly List<TimeTableRow> _timeTable = new()
                                                { new TimeTableRow(new TimeSpan(6,0,0),new TimeSpan(6,29,0),8m),
                                                  new TimeTableRow(new TimeSpan(6,30,0),new TimeSpan(6,59,0),13m),
                                                  new TimeTableRow(new TimeSpan(7,0,0),new TimeSpan(7,59,0),18m),
                                                  new TimeTableRow(new TimeSpan(8,0,0),new TimeSpan(8,29,0),13m),
                                                  new TimeTableRow(new TimeSpan(8,30,0),new TimeSpan(14,59,0),8m),
                                                  new TimeTableRow(new TimeSpan(15,0,0),new TimeSpan(15,29,0),13m),
                                                  new TimeTableRow(new TimeSpan(15,30,0),new TimeSpan(16,59,0),18),
                                                  new TimeTableRow(new TimeSpan(17,0,0),new TimeSpan(17,59,0),13),
                                                  new TimeTableRow(new TimeSpan(18,0,0),new TimeSpan(18,29,0),8)
                                                  
        };

        public decimal CalculationToll(Travel travel)
        {
            var result = _timeTable.FirstOrDefault(t => t.FromTime <= travel.ActionAt.TimeOfDay
                                                    && t.ToTime >= travel.ActionAt.TimeOfDay
                                                 ).Toll;
            return result;
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
