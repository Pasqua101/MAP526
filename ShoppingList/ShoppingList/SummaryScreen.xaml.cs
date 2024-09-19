using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryScreen : ContentPage
    {
        private List<string> shoppingList = new List<string>();

        public SummaryScreen(List<string> shoppingList)
        {
            InitializeComponent();
            this.shoppingList = shoppingList; // set the shoppingList
            lvShoppingList.ItemsSource = shoppingList; // associate the list with the entered items from the previous screen

        }
    }
}