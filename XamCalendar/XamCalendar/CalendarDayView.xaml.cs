using NodaTime;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamCalendar
{
    public partial class CalendarDayView : TemplatedView
    {
        public CalendarDayView()
        {
            InitializeComponent();
        }

        public static BindableProperty DayProperty = BindableProperty.Create(nameof(Day), typeof(CalendarDay), typeof(CalendarDayView), defaultValue: null, defaultBindingMode: BindingMode.OneWay);

        public CalendarDay Day
        {
            get { return (CalendarDay)GetValue(DayProperty); }
            set { SetValue(DayProperty, value); }
        }

        public static BindableProperty SelectDateCommandProperty = BindableProperty.Create(nameof(SelectDateCommand), typeof(ICommand), typeof(CalendarDayView), defaultValue: null, defaultBindingMode: BindingMode.OneWay);

        public ICommand SelectDateCommand
        {
            get { return (ICommand)GetValue(SelectDateCommandProperty); }
            set { SetValue(SelectDateCommandProperty, value); }
        }

        public static BindableProperty TodayColorProperty = BindableProperty.Create(nameof(TodayColor), typeof(Color), typeof(CalendarDayView), defaultValue: Color.DeepPink, defaultBindingMode: BindingMode.OneWay);

        public Color TodayColor
        {
            get { return (Color)GetValue(TodayColorProperty); }
            set { SetValue(TodayColorProperty, value); }
        }

        public static BindableProperty SelectedColorProperty = BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(CalendarDayView), defaultValue: Color.DeepPink, defaultBindingMode: BindingMode.OneWay);

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(CalendarDayView), default(string), defaultBindingMode: BindingMode.OneWay);
        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }
    }

    public class CalendarDay : INotifyPropertyChanged
    {
        public LocalDate LocalDate { get; set; }

        public bool IsToday { get; set; }

        public bool IsSelected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class DayVisiblityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}