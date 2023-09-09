namespace CongestionTax.RuleEngine
{
    public class CalendarRule : CongestionTaxBaseRule
    {
        public CalendarRule(int proiority)
        {
            Proiority = proiority;
        }
        public override bool IsApplicable(Travel travel)
        {
            if (IsTaxFreeDays(travel.ActionAt)) return true;
            return false;
        }

        public override decimal GetTaxFee()
        {
            return 0;
        }

        private bool IsTaxFreeDays(DateTime dt)
        {
            if (dt.IsWeekend() ||
                dt.IsPublicHoliday() ||
                dt.IsDayBeforePublicHoliday()||
                dt.IsJuly())
                return true;
            return false;
        }
    }
}
