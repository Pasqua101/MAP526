using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserProfileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {

        public ProfilePage(Person p)
        {
            InitializeComponent();

            pfpImage.Source = p.pfp;
            nameLabel.Text = p.Name;
            emailLabel.Text = p.email;
        }
    }
}