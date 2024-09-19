using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Class5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            nierArtwork.Source = ImageSource.FromResource("Class5.images.nier.jpg");
        }
    }
}
