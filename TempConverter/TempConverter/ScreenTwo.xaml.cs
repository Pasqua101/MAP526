using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TempConverter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScreenTwo : ContentPage
    {
        public ScreenTwo(double convertedFahrenhiet)
        {
            InitializeComponent();
            fahrenhietResult.Text = convertedFahrenhiet.ToString();
        }

        async private void goBackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync(); // If the Go Back button Was clicked, then bring the user back to the main page (root screen) Can also do this with Navigation.PopAsync() since we have only 2 screens
        }
    }
}