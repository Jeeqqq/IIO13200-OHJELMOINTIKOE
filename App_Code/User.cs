using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace G9206.Classes
{


    [Serializable()]
    [XmlRoot("Users")]
    public class Users
    {
        [XmlElement("User")]
        public List<User> kayttajat { get; set; }

        public Users()
        {
            kayttajat = new List<User>();
        }
    }

    [Serializable()]
    public class User
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("UserName")]
        public string UserName { get; set; }
        [XmlElement("Password")]
        public string Password { get; set; }

        public User()
        {
        }
        public User(string name,string username,string pass)
        {
            Name = name;
            UserName = username;
            Password = pass;
        }
    }
}