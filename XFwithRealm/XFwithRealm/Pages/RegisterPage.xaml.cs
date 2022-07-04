using Realms.Sync;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFwithRealm.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage() => InitializeComponent();

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var email = EmailEntry.Text;
                var password = PasswordEntry.Text;
                var confirmPassword = ConfirmPasswordEntry.Text;
                if (password == confirmPassword)
                {
                    await App.RealmApp.EmailPasswordAuth.RegisterUserAsync(email, password);
                    var user = await App.RealmApp.LogInAsync(Credentials.EmailPassword(email, password));
                    if (user != null)
                    {
                        Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                        await Navigation.PopToRootAsync(true);
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Passwords do not match", "Try Again!");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok!");
            }
        }

        private async void LogInButton_Clicked(object sender, EventArgs e) => await Navigation.PopAsync(true);
    }
}
