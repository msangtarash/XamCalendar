using NodaTime;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamCalendar
{
	public partial class CalenderPopupView : PopupPage 
	{
		public CalenderPopupView ()
		{
			InitializeComponent ();
		}

        public static BindableProperty CultureProperty = BindableProperty.Create(nameof(Culture), typeof(CultureInfo), typeof(CalenderPopupView), defaultValue: CultureInfo.CurrentUICulture, defaultBindingMode: BindingMode.OneTime, propertyChanged: (sender, oldValue, newValue) =>
        {
            CalendarView calendarView = (CalendarView)sender;
            calendarView.CalcCurrentMonthDays();
        });

        public CultureInfo Culture
        {
            get { return (CultureInfo)GetValue(CultureProperty); }
            set { SetValue(CultureProperty, value); }
        }

        public static BindableProperty CalendarSystemProperty = BindableProperty.Create(nameof(CalendarSystem), typeof(CalendarSystem), typeof(CalenderPopupView), defaultValue: CalendarSystem.Gregorian, defaultBindingMode: BindingMode.OneTime, propertyChanged: (sender, oldValue, newValue) =>
        {
            CalendarView calendarView = (CalendarView)sender;
            calendarView.CalcCurrentMonthDays();
        });

        public CalendarSystem CalendarSystem
        {
            get { return (CalendarSystem)GetValue(CalendarSystemProperty); }
            set { SetValue(CalendarSystemProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(CalenderPopupView), defaultValue: null, defaultBindingMode: BindingMode.OneTime);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static BindableProperty SelectedDateProperty = BindableProperty.Create(nameof(SelectedDate), typeof(DateTime?), typeof(CalenderPopupView), defaultValue: null, defaultBindingMode: BindingMode.OneTime);

        // ToDo: SelectedDate must be two way
        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }

        public static BindableProperty TodayColorProperty = BindableProperty.Create(nameof(TodayColor), typeof(Color), typeof(CalenderPopupView), defaultValue: Color.DeepPink, defaultBindingMode: BindingMode.OneWay);

        public Color TodayColor
        {
            get { return (Color)GetValue(TodayColorProperty); }
            set { SetValue(TodayColorProperty, value); }
        }

        public static BindableProperty SelectedColorProperty = BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(CalenderPopupView), defaultValue: Color.DeepPink, defaultBindingMode: BindingMode.OneWay);

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }
    }
}
