using Xamarin.Forms;

namespace XamCalendar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TestView { };
        }
    }
}
