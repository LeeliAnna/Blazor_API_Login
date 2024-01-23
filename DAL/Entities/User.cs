using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User()
        {
            
        }

        public User(int id, string pseudo, string password, string email)
        {
            Id = id;
            Pseudo = pseudo;
            Password = password;
            Email = email;
        }
    }
}
