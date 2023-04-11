using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StaycationDemo.Helpers;
using StaycationDemo.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace StaycationDemo.Models.SQLRepositories
{
    public class SQLUserRepository : IUserRepository
    {
        private static readonly string connectionString = AppDbContext.ConnectionString;
        
        public IEnumerable<User> AllUsers()
        {
            List<User> allUsers = new List<User>();
            string query = "Select * from Users";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    User user = new User();

                    user.Email = dataTable.Rows[i]["Email"].ToString();
                    user.FirstName = dataTable.Rows[i]["FirstName"].ToString();
                    user.LastName = dataTable.Rows[i]["LastName"].ToString();
                    user.Password = dataTable.Rows[i]["Password"].ToString();

                    allUsers.Add(user);
                }
            }
            return allUsers;
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            User user = null;
            var allUsers = AllUsers();
            if (allUsers != null && allUsers.Count() != 0)
            {
                foreach (var c in allUsers)
                {
                    if (c.Email == email || c.Password == password)
                        user = c;
                }
            }

            return user;
        }

        public bool SaveCustomer(User user)
        {
            bool isSaved = false;
            string query = "INSERT INTO Users(Email, FirstName, LastName, Password)" +
                            "VALUES(@param1, @param2, @param3, @param4)";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    using (SqlCommand command = sqlConnection.CreateCommand())
                    {
                        command.CommandText = query;
                        command.Parameters.AddWithValue("@param1", user.Email);
                        command.Parameters.AddWithValue("@param2", user.FirstName);
                        command.Parameters.AddWithValue("@param3", user.LastName);
                        command.Parameters.AddWithValue("@param4", user.Password);

                        command.ExecuteNonQuery();
                    }
                    isSaved = true;
                }
                catch (DbException e)
                {
                    Console.WriteLine(e.ToString());
                }
                
            }
            return isSaved;
        }
    }
}
