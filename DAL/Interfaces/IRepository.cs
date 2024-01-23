using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository
    {
        public User CreateUser(User user);
        public User? GetUserById(int id);
        public User? GetUserByEmail(string email);
        public IEnumerable<User> GetAllUsers();
        public bool UpdateUser(User user);
        public bool DeleteUser(User user);
    }
}
