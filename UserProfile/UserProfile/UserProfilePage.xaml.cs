using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserProfile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage(UserModel user)
        {
            InitializeComponent();
            pfpImage.Source = user.profilePicture;
            nameLabel.Text = user.name;
            emailLabel.Text = user.email;
        }
    }
}