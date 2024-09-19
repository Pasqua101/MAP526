using System;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Library_marco
{
    public class MyDatabase
    {
        private string tableName = "BooksDatabase";

        // defining a connection to the db
        readonly SQLiteAsyncConnection dbConnection;

        public MyDatabase()
        {
            // Configuring the connection

            // specifying the name of the db file
            string databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, $"{tableName}.db");
            Console.WriteLine($"++++++ Database path: {databasePath}");

            // specifying "where" on the device the file will be saved
            dbConnection = new SQLiteAsyncConnection(databasePath);

            // Creating the table
            dbConnection.CreateTableAsync<BookModel>().Wait();

            Console.WriteLine($"++++++ Database table created!");
        }

        // CRUD operations

        // Insert Operations

        public async Task<int> AddBook(BookModel bookToAdd)
        {
            int numOfRowsAdded = await dbConnection.InsertAsync(bookToAdd);
            return numOfRowsAdded;
        }

        // GET Operations

        public async Task<List<BookModel>> GetAllBooks()
        {
            // grab all books from BookModel table and convert it into a List
            return await dbConnection.Table<BookModel>().ToListAsync();
        }

        // UPDATE Operations

        // UPDATE db to CHECKOUT OR RETURN a book
        public async Task<int> CheckoutOrReturnBook(BookModel bookToUpdate)
        {
            return await dbConnection.UpdateAsync(bookToUpdate);
        }

        // DELETE Operations
        public async Task DeleteAllRows()
        {
            await dbConnection.DeleteAllAsync<BookModel>();
        }
    }
}
