using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class DBMapper
    {
        public static User ToUser(this Microsoft.Data.SqlClient.SqlDataReader reader)
        {
            return new User()
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString(),
                Pseudo = reader["Pseudo"].ToString()
            };
        }
    }
}
