using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UserProfile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void submitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserProfilePage(new UserModel(nameEntry.Text, emailEntry.Text, pfpEntry.Text)));
        }
    }
}
