using System;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace XFwithAuth0
{
    public partial class MainPage : ContentPage
    {
        private readonly IUserAuthService userAuthService;

        public MainPage()
        {
            InitializeComponent();
            userAuthService = DependencyService.Get<IUserAuthService>();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var loginResult = await userAuthService.Auth0UserLogin();
            var result = new StringBuilder();
            if (loginResult.IsError)
            {
                Message.Text = "An error occured during login.";
                result.AppendLine($"An error occured during login: {loginResult.Error}");

                Console.WriteLine(result.ToString());
            }
            else
            {
                Profile.Source = loginResult.User.Claims.First(p => p.Type == "picture").Value;
                Username.Text = $"Welcome {loginResult.User.Claims.First(u => u.Type == "nickname").Value}";
                Email.Text = $"Email: {loginResult.User.Identity.Name}";

                result.AppendLine("------ User Claims ------");
                foreach (var claim in loginResult.User.Claims)
                {
                    result.AppendLine($"{claim.Type} = {claim.Value}");
                }

                Console.WriteLine(result.ToString());

                LoginButton.IsVisible = false;
                LogoutButton.IsVisible = true;
            }
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            await userAuthService.Auth0UserLogout();
            Username.IsVisible = false;
            Email.IsVisible = false;
            LogoutButton.IsVisible = false;
            LoginButton.IsVisible = true;
            Message.Text = "User logged out!";
        }
    }
}
