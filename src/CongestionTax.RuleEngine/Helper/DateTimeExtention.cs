using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTax.RuleEngine
{
    public static class DateTimeExtention
    {
        public static bool IsWeekend(this DateTime value)
        {
            return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
        }
        public static bool IsJuly(this DateTime value)
        {
            return (value.Month == 7);
        }
        public static bool IsPublicHoliday(this DateTime dt)
        {
            var year = dt.Year;
            var date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    if (GothenburgPublicHoliday.NewYear(year) == date)
                        return true;
                    if (GothenburgPublicHoliday.Epiphany(year) == date)
                        return true;
                    break;

                case 3:
                case 4:
                    if (GothenburgPublicHoliday.WomensDay(year) == date)
                        return true;
                    break;

                case 5:
                case 6:
                    if (GothenburgPublicHoliday.MayDay(year) == date)
                        return true;
                    break;

                case 8:
                    if (GothenburgPublicHoliday.Assumption(year) == date)
                        return true;
                    break;

                case 9:
                    if (GothenburgPublicHoliday.WorldChildrensDay(year) == date)
                        return true;
                    break;

                case 10:
                case 11:

                case 12:
                    if (GothenburgPublicHoliday.Christmas(year) == date)
                        return true;

                    break;
            }

            return false;
        }
        public static bool IsDayBeforePublicHoliday(this DateTime dt)
        { return dt.AddDays(-1).IsPublicHoliday(); }

    }
}
