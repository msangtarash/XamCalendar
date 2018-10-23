using NodaTime;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamCalendar
{
    public partial class CalendarView : TemplatedView
    {
        public CalendarView()
        {
            InitializeComponent();

            bool usePersian = false; // for debug

            if (usePersian == true)
            {
                Direction = FlowDirection.RightToLeft;
                Culture = new CultureInfo("fa"); // CultureInfo.CurrentUICulture;
                CalendarSystem = CalendarSystem.PersianArithmetic;
            }
            else
            {
                Direction = FlowDirection.LeftToRight;
                Culture = new CultureInfo("en"); // CultureInfo.CurrentUICulture;
                CalendarSystem = CalendarSystem.Gregorian;
            }

            DayOfWeek firstDayOfWeekOfCurrentCulture = Culture.DateTimeFormat.FirstDayOfWeek;

            List<DayOfWeekInfo> daysOfWeek = Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>()
                .OrderBy(d => (d - firstDayOfWeekOfCurrentCulture + 7) % 7)
                .Select((d, i) => new DayOfWeekInfo
                {
                    DayOfWeek = d,
                    DayOfWeekNumber = i + 1,
                    IsoDayOfWeek = (IsoDayOfWeek)Enum.Parse(typeof(IsoDayOfWeek), d.ToString()),
                    DayOfWeekName = Culture.DateTimeFormat.GetAbbreviatedDayName(d)
                })
                .ToList();

            DaysOfWeekNames = daysOfWeek.Select(d => d.DayOfWeekName).ToArray();

            CurrentMonth = new LocalDate(DateTimeOffset.Now.Year, DateTimeOffset.Now.Month, DateTimeOffset.Now.Day, CalendarSystem.Gregorian).WithCalendar(CalendarSystem);

            CalendarTitle = CurrentMonth.ToString("MMM yyyy", Culture);

            int thisMonthDaysCount = CurrentMonth.Calendar.GetDaysInMonth(CurrentMonth.Year, CurrentMonth.Month);

            LocalDate firstDayOfMonth = LocalDate.Subtract(CurrentMonth, Period.FromDays(CurrentMonth.Day - 1));
            DayOfWeekInfo firstDayOfMonthDayOfWeek = daysOfWeek.Single(d => d.IsoDayOfWeek == firstDayOfMonth.DayOfWeek);

            int prevMonthDaysInCurrentMonthView = (firstDayOfMonthDayOfWeek.DayOfWeekNumber - 1);
            int nextMonthDaysInCurrentMonthView = 35 - thisMonthDaysCount - prevMonthDaysInCurrentMonthView;

            Days = new List<CalendarDay>(35);

            for (int i = 0; i < prevMonthDaysInCurrentMonthView; i++)
            {
                Days.Add(null);
            }

            for (int i = 1; i <= thisMonthDaysCount; i++)
            {
                Days.Add(new CalendarDay
                {
                    LocalDate = new LocalDate(CurrentMonth.Year, CurrentMonth.Month, i, CurrentMonth.Calendar)
                });
            }

            for (int i = 0; i < nextMonthDaysInCurrentMonthView; i++)
            {
                Days.Add(null);
            }

            //LocalDate.Add(CurrentMonth, Period.FromMonths(1)); >> for +
            //LocalDate.Subtract(CurrentMonth, Period.FromMonths(1)); >> for -
        }

        // internal usage:
        public string CalendarTitle { get; set; }
        public string[] DaysOfWeekNames { get; set; }
        public List<CalendarDay> Days { get; set; }
        public LocalDate CurrentMonth { get; set; }

        // bindable props:
        public CalendarSystem CalendarSystem { get; set; }
        public CultureInfo Culture { get; set; }
        public FlowDirection Direction { get; set; }
    }

    public class DayOfWeekInfo
    {
        public IsoDayOfWeek IsoDayOfWeek { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// Based on current culture.
        /// </summary>
        public string DayOfWeekName { get; set; }

        /// <summary>
        /// Based on current culture.
        /// </summary>
        public int DayOfWeekNumber { get; set; }
    }

    public class CalendarDay
    {
        public LocalDate LocalDate { get; set; }

        // IsToday
        // IsSelected
    }
}