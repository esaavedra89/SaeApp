using SaeApp.View.Modules.Inventory;
using SaeApp.View.Modules.SAE;
using Xamarin.Forms;

namespace SaeApp
{
    public partial class App : Application
    {
        /// </summary>
        public static MasterDetailPage MasterD { get; set; }

        public int IdResource { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"]
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
