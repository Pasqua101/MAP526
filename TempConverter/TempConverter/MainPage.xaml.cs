using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TempConverter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void convertButton_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(celsiusEntry.Text, out double convertedTemp))
            {
                // If a valid temp was enetered push the user to the next screen after doing the conversion

                double fahrenhiet = (convertedTemp * 9/5) + 32;

                await Navigation.PushAsync(new ScreenTwo(fahrenhiet));
            }
            else
            {
                // If it wasn't then show an error
                errLabel.IsVisible = true;
            }
        }
    }
}
