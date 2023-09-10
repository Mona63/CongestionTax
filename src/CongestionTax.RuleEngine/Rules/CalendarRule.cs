namespace CongestionTax.RuleEngine
{
    public class CalendarRule : ITaxFreeRule
    {
        public int Proiority { get; set; }
        public  bool IsApplicable(Travel travel)
        {
            var result = IsTaxFreeDay(travel.ActionAt);
            return result;
        }

        private bool IsTaxFreeDay(DateTime dt)
        {
            var result = (dt.IsWeekend() ||
                          dt.IsPublicHoliday() ||
                          dt.IsDayBeforePublicHoliday() ||
                          dt.IsJuly());
            return result;
        }
    }
}
