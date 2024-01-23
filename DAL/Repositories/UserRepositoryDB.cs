using DAL.Entities;
using DAL.Interfaces;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepositoryDB : IRepository
    {
        private readonly string _connectionString;
        public UserRepositoryDB(string connectionString)
        {
            _connectionString = connectionString;
        }
        public User CreateUser(User user)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand()) 
                {
                    cmd.CommandText = "INSERT INTO Users OUTPUT inserted.id VALUES (@email, @password, @pseudo)";

                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("pseudo", user.Pseudo);
                    cmd.Parameters.AddWithValue("password", user.Password);

                    conn.Open();

                    user.Id = (int)cmd.ExecuteScalar();

                    conn.Close();

                    return user;
                }

            }
        }

        public bool DeleteUser(User user)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Users WHERE id = @id";

                    cmd.Parameters.AddWithValue("id", user.Id);

                    conn.Open();

                    int rowAffected = cmd.ExecuteNonQuery();

                    conn.Close();

                    return rowAffected == 1;
                }
            }
        }

        public List<User> GetAllUsers()
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users";

                    conn.Open();

                    SqlDataReader reder = cmd.ExecuteReader();

                    List<User> users = new List<User>();
                    while (reder.Read())
                    {
                        users.Add(reder.ToUser());
                    }

                    conn.Close();
                    return users;
                }
            }
        }

        public User? GetUserByEmail(string email)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Email = @email";
                    cmd.Parameters.AddWithValue ("email", email);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    User? u = null;

                    while (reader.Read())
                    {
                        u = reader.ToUser();
                    }
                    conn.Close();

                    return u;
                }
            }
        }

        public User? GetUserById(int id)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Id = @id";
                    cmd.Parameters.AddWithValue("Id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    User? u = null;
                    while (reader.Read())
                    {
                        u = reader.ToUser();
                    }
                    conn.Close();
                    return u;
                }
            }
        }

        public bool UpdateUser(User user)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Users SET Email = @email, Password = @password, Pseudo = @pseudo WHERE Id = @id";
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.Parameters.AddWithValue("pseudo", user.Pseudo);
                    cmd.Parameters.AddWithValue("id", user.Id);

                    conn.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowAffected == 1;
                }
            }
        }
    }
}
