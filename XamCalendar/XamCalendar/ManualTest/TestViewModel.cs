using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamCalendar
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public DateTime? SelectedDate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TestViewModel()
        {
            SelectedDate = DateTime.Now;

            ChangeDate = new Command(() =>
            {
                SelectedDate = SelectedDate == null ? DateTime.Now : (DateTime?)null; // swap between null and now!
            });
        }

        public Command ChangeDate { get; set; }
    }
}
