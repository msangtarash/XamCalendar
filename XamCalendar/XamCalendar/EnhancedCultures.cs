using System.Globalization;

namespace XamCalendar
{
    public static class EnhancedCultures
    {
        private static CultureInfo _persian;

        public static CultureInfo EnhancedPersian
        {
            get
            {
                if (_persian == null)
                {
                    _persian = new CultureInfo("Fa");
                    _persian.DateTimeFormat.MonthNames = _persian.DateTimeFormat.AbbreviatedMonthGenitiveNames = _persian.DateTimeFormat.MonthGenitiveNames = _persian.DateTimeFormat.AbbreviatedMonthNames = new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
                }

                return _persian;
            }
        }
    }
}
