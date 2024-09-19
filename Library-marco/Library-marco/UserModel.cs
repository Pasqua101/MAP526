using System;
using System.Collections.Generic;
using System.Text;

namespace Library_marco
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }


        public UserModel() { }

        public UserModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
