using NodaTime;
using Rg.Plugins.Popup.Services;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamCalendar
{
    public class TestViewModel : INotifyPropertyChanged 
    {
        private CalenderPopupView _testPopupPage;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command OpenPopupCommand { get; set; }

        public TestViewModel()
        {
            OpenPopupCommand = new Command( async () =>
            {
                _testPopupPage = new CalenderPopupView();

                await PopupNavigation.Instance.PushAsync(_testPopupPage);
            });
        }
    }
}
