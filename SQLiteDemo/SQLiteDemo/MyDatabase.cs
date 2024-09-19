using System;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic; // Allows us to use a List

namespace SQLiteDemo
{
    public class MyDatabase
    {

        // 1. Define a property that represents the connection to the database
        // - C# property modifier
        // - only the constructor can modify the value of this property
        // (no other methods in the class can modify it)
        readonly SQLiteAsyncConnection dbConnection;

        public MyDatabase()
        {
            // Configure the connection

            // - specifying the name of the database file
            string databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "TodoDatabase.db");
            Console.WriteLine($"++++++ Database path: {databasePath}");

            // - specify "where" on the device the file will be saved
            dbConnection = new SQLiteAsyncConnection(databasePath);

            // Create the table (based on the TodoItem)
            dbConnection.CreateTableAsync<ToDoItem>().Wait();

            // Done!
            Console.WriteLine($"++++++ Database table created!");
        }

        // CRUD operations
        public async Task<int> AddItem(ToDoItem itemToAdd)
        {
            // INSERT INTO TodoItems (...,...,..,)
            int numRowsAdded = await dbConnection.InsertAsync(itemToAdd);
            return numRowsAdded;
        }

        // GET everything from the table
        public async Task<List<ToDoItem>> GetAllItems()
        {
            // grab items from the ToDoItem table and convert it into a List
            List<ToDoItem> resultsList = await dbConnection.Table<ToDoItem>().ToListAsync(); // works like a SELECT * query
            return resultsList;
        }

        // GET a single item by its primary key
        public async Task<ToDoItem> GetItemById(int id)
        {
            // grab item from the ToDoItem table based on the provided id
            ToDoItem result = await dbConnection.GetAsync<ToDoItem>(id); // works like SELECT * FROM ToDoItem WHERE id = 1
            return result;
        }

        // GETS items based on a manual SQL query
        public async Task<List<ToDoItem>> GetItemsByPriority(bool priority)
        {
            // grab items from the ToDoItem table where they are high priority
            List<ToDoItem> results = await dbConnection.QueryAsync<ToDoItem>("SELECT * FROM ToDoItem WHERE IsHighPriority = ?", priority); // runs an actual query
            return results;
        }

        // UPDATE an existing item
        public async Task<int> UpdateItem(ToDoItem item)
        {
            return await dbConnection.UpdateAsync(item); // returns number of rows updated
        }

        // DELETE an item
        public async Task<int> DeleteItemById(int id)
        {
            return await dbConnection.DeleteAsync<ToDoItem>(id); // returns number of objects(rows) deleted
        }
    }
}