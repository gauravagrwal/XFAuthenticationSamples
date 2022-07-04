using Xamarin.Forms;
using XFwithRealm.Pages;

namespace XFwithRealm
{
    public partial class App : Application
    {
        private const string APP_ID = "xfwithrealm-dpnjr";
        public static Realms.Sync.App RealmApp;

        public App() => InitializeComponent();

        protected override void OnStart()
        {
            RealmApp = Realms.Sync.App.Create(APP_ID);
            if (RealmApp.CurrentUser != null)
                MainPage = new NavigationPage(new MainPage());
            else
                MainPage = new NavigationPage(new LogInPage());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
