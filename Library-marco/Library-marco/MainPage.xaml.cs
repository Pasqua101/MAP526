using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Library_marco
{
    public partial class MainPage : ContentPage
    {
        // Creating an intance of the MyDatabase class (implented as a singleton)
        private static MyDatabase db;
        public static MyDatabase MyDb
        {
            get
            {
                if (db == null)
                {
                    db = new MyDatabase();
                }
                return db;
            }
        }

        //Creating users when the app is launched
        UserModel user1 = new UserModel("peter", "1234");
        UserModel user2 = new UserModel("mary", "0000");

        public MainPage()
        {
            InitializeComponent();

            /*DeleteAllBooks();*/

            // Creating rows on the DB for the books
            /*BookModel book1 = new BookModel("1338878921", "Harry Potter and the Sorcerer's Stone", "J. K. Rowling", false, "");
            AddBookToDB(book1);*/

            /*BookModel book2 = new BookModel("1942993889", "BAKEMONOGATARI, Part 1 (novel): Monster Tale", "NISIOISIN", false, "");
            AddBookToDB(book2);*/

            /*BookModel book3 = new BookModel("1942993897", "BAKEMONOGATARI, Part 2 (novel): Monster Tale", "NISIOISIN", false, "");
            AddBookToDB(book3);*/

            /*BookModel book4 = new BookModel("1942993900", "BAKEMONOGATARI, Part 3 (novel): Monster Tale", "NISIOISIN", false, "");
            AddBookToDB(book4);*/

            /*BookModel book5 = new BookModel("1647291550", "KATANAGATARI 1 (paperback): Sword Tale", "NISIOISIN", false, "");
            AddBookToDB(book5);

            BookModel book6 = new BookModel("1974725987", "Kaiju No. 8, Vol. 1", "Matsumoto, Naoya", false, "");
            AddBookToDB(book6);

            BookModel book7 = new BookModel("197470162X", "NieR:Automata: Long Story Short", "Eishima, Jun; Taro, Yoko", false, "");
            AddBookToDB(book7);

            BookModel book8 = new BookModel("1591169208", "Fullmetal Alchemist, Vol. 1", "Arakawa, Hiromu", false, "");
            AddBookToDB(book8);*/
        }
        // When the user moves onto the next screen, reset the text entered in the entry fields
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            usernameEntry.Text = "";
            passwordEntry.Text = "";
            errLabel.IsVisible = false;
        }

        private async void AddBookToDB(BookModel bookToAdd)
        {
            int results = await MainPage.MyDb.AddBook(bookToAdd);
            if (results > 0)
            {
                Console.WriteLine("SUCCESS: Book Added!");
            }
            else
            {
                Console.WriteLine("ERROR: Book Could Not Be Added.");
            }

        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            // Get the text entered in the entries
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            // Make sure that none of the fields are empty
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                // If the fields are not empty, make sure that they match one of the users that were statically coded in
                if (username == user1.username && password == user1.password)
                {
                    // pass user to next screen while also bringing over the user object
                    await Navigation.PushAsync(new BooksListScreen(user1));
                }
                else if (username == user2.username && password == user2.password)
                {
                    // pass user to next screen
                    await Navigation.PushAsync(new BooksListScreen(user2));
                }
                // show an error if none of the above users where found with the provided text
                else
                {
                    showErrorLabel("ERROR: Incorrect username or password", Color.Red);
                }

            }
            // Show an error message
            else
            {
                showErrorLabel("ERROR: Username or password cannot be empty", Color.Red);
            }

        }

        // Helper Functions

        public void showErrorLabel(string text, Color backgroundColor)
        {
            errLabel.Text = text;
            errLabel.BackgroundColor = backgroundColor;
            errLabel.IsVisible = true;
        }

        private async void DeleteAllBooks()
        {
            await MainPage.MyDb.DeleteAllRows();
        }
    }
}
