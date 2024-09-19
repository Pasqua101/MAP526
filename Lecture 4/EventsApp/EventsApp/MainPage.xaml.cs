using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EventsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e) {
            Console.WriteLine("Button clicked");

            string name = txtName.Text;
            string age = txtAge.Text;

            // Converting the age string to an int
            
            if(Int32.TryParse(age, out int tempAge))
            {
                int updatedAge = tempAge + 5;
                resultLabel.Text = $"Your name is {name}. You will be {updatedAge} in 5 years.";
            }
            else
            {
                resultLabel.Text = "Could not convert from string to int: age";
            }

            
        }
    }
}
