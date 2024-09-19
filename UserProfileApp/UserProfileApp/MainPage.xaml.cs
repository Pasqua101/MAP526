using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UserProfileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void profileButton_Clicked(object sender, EventArgs e)
        {
            // Create a person object and set the text from the entry fields
            Person person = new Person(nameEntry.Text, emailEntry.Text, pfpEntry.Text);

            // Check to see if the text is empty
            if (!string.IsNullOrEmpty(person.Name) && !string.IsNullOrEmpty(person.email) && !string.IsNullOrEmpty(person.pfp))
            {
                await Navigation.PushAsync(new ProfilePage(person));
            }
            else
            {
                errLabel.IsVisible = true;
            }
        }
    }
}
