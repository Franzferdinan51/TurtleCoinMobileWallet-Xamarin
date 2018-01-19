using TurtleWallet.Views;
using Xamarin.Forms;

namespace TurtleWallet
{
    public partial class App : Application
    {
        public RootPage RootPage { get; private set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LandingPage());
        }
    }
}
