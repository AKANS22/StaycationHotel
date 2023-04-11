using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StaycationDemo.Helpers;
using StaycationDemo.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace StaycationDemo.Models.SQLRepositories
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private static readonly string connectionString = AppDbContext.ConnectionString;
        public IEnumerable<Category> AllCategories()
        {
            List<Category> allCategories = new List<Category>();
            string query = "Select * from Categories";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Category category = new Category();

                    category.CategoryId = int.Parse(dataTable.Rows[i]["CategoryId"].ToString());
                    category.CategoryName = dataTable.Rows[i]["CategoryName"].ToString();
                    category.Description = dataTable.Rows[i]["Description"].ToString();

                    allCategories.Add(category);
                }
            }
            return allCategories;
        }
    }
}
