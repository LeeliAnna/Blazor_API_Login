using BLL.Forms;
using BLL.Mapper;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserServices
    {
        // Injection de dépendance de la couche DAL
        private readonly IRepository _repository;

        public UserServices(IRepository repository)
        {
            _repository = repository;
        }

        public User? Create(RegisterForm form)
        {
            User? u = _repository.GetUserByEmail(form.Email);

            if(u is not null)
            {
                User user = form.ToUser();
                user.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
                user = _repository.CreateUser(user);
                return user;
            }
            return null;
        }
        
        public bool EmailAlreadyUsed(string email)
        {
            return _repository.GetUserByEmail(email) is not null;
        }

        public User? GetById(int id)
        {
            return _repository.GetUserById(id);
        }

        public List<User> GetAll()
        {
            return _repository.GetAllUsers();
        }

        public bool UpdatePassword(UpdatePasswordForm form)
        {
            User? u = _repository.GetUserById(form.Id);
            if(u is not null)
            {
                if (BCrypt.Net.BCrypt.Verify(form.OldPassword, u.Password))
                {
                    u.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
                    return _repository.UpdateUser(u);
                }
            }
            return false;
        }

        public bool Delete(int id)
        {
            User? u = _repository.GetUserById(id);
            if (u is not null)
            {
                return _repository.DeleteUser(u);
            }
            return false;
        }

        public User? GetByEmail(string email)
        {
            return _repository.GetUserByEmail(email);
        }

        public User? Login(string email, string password)
        {
            User? u = _repository.GetUserByEmail(email);
            if(BCrypt.Net.BCrypt.Verify(password, u.Password))
            {
                return u;
            }
            return null;
        }
    }
}
