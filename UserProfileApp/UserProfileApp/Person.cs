using System;
using System.Collections.Generic;
using System.Text;

namespace UserProfileApp
{
    public class Person
    {
        public string Name { get; set; }
        public string email { get; set; }
        public string pfp { get; set; }

        public Person(string name, string email, string pfp)
        {
            this.Name = name;
            this.email = email;
            this.pfp = pfp;
        }
    }
}
