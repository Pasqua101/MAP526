using System;
using System.Collections.Generic;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment_2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksListScreen : ContentPage
    {

        // Variable to hold all the books from the DB
        private List<BookModel> booksList = new List<BookModel>();

        // Global variable for the user
        private UserModel user = new UserModel();

        public BooksListScreen(UserModel loggedInUser)
        {
            InitializeComponent();
            InitializeScreen(loggedInUser);
        }

        private async void InitializeScreen(UserModel loggedInUser)
        {

            // Allowing the loggedInUser instance of UserModel to be globally available to the rest of the code
            user = loggedInUser;

            // Get all the books from the DB and put it in booksList
            booksList = await MainPage.MyDb.GetAllBooks();

            // Initialize the booksListView
            booksListView.ItemsSource = booksList;

            // greet the currently logged in user
            welcomeLabel.Text = $"Welcome {loggedInUser.username}!";
        }


        private void booksListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Getting the selected book
            BookModel selectedBook = e.Item as BookModel;

            // Making sure that it isn't null
            if (selectedBook == null)
            {
                return;
            }

            // Check to see if the book is already borrowed
            if (selectedBook.borrowStatus == true)
            {
                // If the user who checked it out is logged in, tell them they checked it out
                if (selectedBook.borrowerName == user.username)
                {
                    ShowBookStatusLabel("You checked out this book!");
                }

                // Otherwise say who has checked it out
                else
                {
                    ShowBookStatusLabel($"Sorry, {selectedBook.title} is already checked out by {selectedBook.borrowerName}.");
                }
            }

            // If the book is not checked out, tell the user it is available
            else
            {
                ShowBookStatusLabel($"{selectedBook.title} is available for checkout.");
            }
        }


        private void Return_Clicked(object sender, EventArgs e)
        {
            // Getting the selected book
            var menuItem = sender as MenuItem;
            var selectedBook = menuItem?.CommandParameter as BookModel;

            // Return the book
            ReturnBook(selectedBook);
        }

        private void Checkout_Clicked(object sender, EventArgs e)
        {
            // Getting the selected book
            var menuItem = sender as MenuItem;
            var selectedBook = menuItem?.CommandParameter as BookModel;

            // Return the book
            CheckoutBook(selectedBook);
        }

        // Helper functions
        private void ShowBookStatusLabel(string text)
        {
            bookStatusLabel.Text = text;
            bookStatusLabel.IsVisible = true;
        }

        public async void alertBuilder(string title, string message) // Ok action will be default
        {
            await DisplayAlert(title, message, "OK");
        }

        private void ChangeToolBarColor(Color color)
        {
            var navigationPage = (NavigationPage)Application.Current.MainPage;
            navigationPage.BarBackgroundColor = color;
        }

        // Database functions
        
        // Uses the globally defined User instance that we made
        private async void CheckoutBook(BookModel bookToCheckout)
        {
            // Check to see if the book has already been checked out
            if (bookToCheckout.borrowStatus)
            {
                alertBuilder("Error", "You can not check this book out.");
                return;
            }

            // Update the checked out book with the user who checked it out, and set the checkoutStatus to be true
            bookToCheckout.borrowerName = user.username;
            bookToCheckout.borrowStatus = true;

            try
            {
                // Update book on DB
                await MainPage.MyDb.CheckoutOrReturnBook(bookToCheckout);
            } 
            catch
            {
                alertBuilder("Error", "Unable to checkout book.");
                return;
            }

            alertBuilder("Success", "You have checked out your book!");
            bookStatusLabel.IsVisible = false;
            booksListView.SelectedItem = null;
        }

        private async void ReturnBook(BookModel bookToReturn)
        {
            // Check to see if the book has not already been checked out or if the person trying to return it is not the person who checked it out
            if (bookToReturn.borrowStatus == false || bookToReturn.borrowerName != user.username)
            {
                alertBuilder("Error", "This book cannot be returned.");
                return;
            }

            // Set the borrowerName to null and borrowStatus back to false
            bookToReturn.borrowerName = "";
            bookToReturn.borrowStatus = false;

            // Update book on DB
            try
            {
                await MainPage.MyDb.CheckoutOrReturnBook(bookToReturn);
            }
            catch 
            {
                alertBuilder("Error", "Unable to return book.");
                return;
            }

            alertBuilder("Success", "You have returned your book!");
            bookStatusLabel.IsVisible = false;
            booksListView.SelectedItem = null;
        }        
    }
}