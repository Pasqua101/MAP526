using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class MainPage : ContentPage
    {

        private List<string> shoppingList = new List<string>();
        public MainPage()
        {
            InitializeComponent();
        }

        async private void summaryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SummaryScreen(shoppingList));
        }

        private void addToCartButton_Clicked(object sender, EventArgs e)
        {
            string itemEntered = shoppingItemEntry.Text;
            // Check to see if the entry is empty
            if (!string.IsNullOrEmpty(itemEntered))
            {
                shoppingList.Add(itemEntered);
            }
            else
            {
                errLabel.IsVisible = true;
            }
        }
    }
}
