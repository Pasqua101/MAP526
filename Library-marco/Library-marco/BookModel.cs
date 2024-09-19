using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_marco
{
    public class BookModel
    {
        // Defining a primary key
        [PrimaryKey] public string ISBN { get; set; }

        public string title { get; set; }
        public string author { get; set; }
        public bool borrowStatus { get; set; }
        public string borrowerName { get; set; }

        // manadatory to have for SQLite
        public BookModel()
        {

        }

        // By default the borrow status should be set to false and borrowerName should be empty
        public BookModel(string ISBN, string title, string author, bool borrowStatus, string borrowerName)
        {
            this.ISBN = ISBN;
            this.title = title;
            this.author = author;
            this.borrowStatus = borrowStatus;
            this.borrowerName = borrowerName;
        }


    }
}
