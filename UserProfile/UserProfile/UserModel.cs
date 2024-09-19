using System;
using System.Collections.Generic;
using System.Text;

namespace UserProfile
{
    public class UserModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string profilePicture { get; set; }
        
        public UserModel() { }

        public UserModel(string name, string email, string profilePicture)
        {
            this.name = name;
            this.email = email;
            this.profilePicture = profilePicture;
        }

    }
}
