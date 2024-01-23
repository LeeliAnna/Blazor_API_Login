using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepositoryFakeDB : IRepository
    {
        // Conection string DESKTOP-OP2OICK\Gaelle
        public User CreateUser(User user)
        {
            int id = FakeDB.Users.Max(x => x.Id) + 1;
            user.Id = id;
            FakeDB.Users.Add(user);
            return user;
        }

        public bool DeleteUser(User user)
        {
            FakeDB.Users.Remove(user);
            return true;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FakeDB.Users;
        }

        public User? GetUserById(int id)
        {
            User u = FakeDB.Users.Find(x => x.Id == id);
            return u;
        }

        public User? GetUserByEmail(string email)
        {
            User? u = FakeDB.Users.Find(x => x.Email == email);
            return u;
        }

        public bool UpdateUser(User user)
        {
            User? u = FakeDB.Users.Find(x => x.Id == user.Id);
            if (u != null)
            {
                u.Pseudo = user.Pseudo;
                u.Email = user.Email;
                u.Password = user.Password;
                return true;
            }
            return false;
        }
    }
}
