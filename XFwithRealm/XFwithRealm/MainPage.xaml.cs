using System;
using Xamarin.Forms;
using XFwithRealm.Pages;

namespace XFwithRealm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LogOutItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (App.RealmApp.CurrentUser != null)
                {
                    await App.RealmApp.CurrentUser.LogOutAsync();
                    Navigation.InsertPageBefore(new LogInPage(), this);
                    await Navigation.PopAsync(true);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok!");
            }
        }
    }
}
