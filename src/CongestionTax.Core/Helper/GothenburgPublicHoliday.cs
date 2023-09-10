namespace CongestionTax.Core
{
    public static class GothenburgPublicHoliday
    {
        public static DateTime NewYear(int year)
        {
            return new DateTime(year, 1, 1);
        }
        public static DateTime Epiphany(int year)
        {
            return new DateTime(year, 1, 6);
        }
        public static DateTime MayDay(int year)
        {
            return new DateTime(year, 5, 1);
        }
        public static DateTime Assumption(int year)
        {
            return new DateTime(year, 8, 15);
        }
        public static DateTime WorldChildrensDay(int year)
        {
            return new DateTime(year, 9, 20);
        }
        public static DateTime Christmas(int year)
        {
            return new DateTime(year, 12, 25);
        }
        public static DateTime WomensDay(int year)
        {
            return new DateTime(year, 3, 8);
        }
    }
}