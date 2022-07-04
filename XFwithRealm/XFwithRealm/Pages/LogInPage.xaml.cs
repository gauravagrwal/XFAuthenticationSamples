using Realms.Sync;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFwithRealm.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage() => InitializeComponent();

        private async void LogInButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var email = EmailEntry.Text;
                var password = PasswordEntry.Text;
                var user = await App.RealmApp.LogInAsync(Credentials.EmailPassword(email, password));
                if (user != null)
                {
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync(true);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok!");
            }
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new RegisterPage(), true);
    }
}
