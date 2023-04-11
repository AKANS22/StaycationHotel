using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StaycationDemo.Models.Abstractions;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using StaycationDemo.Helpers;

namespace StaycationDemo.Models.SQLRepositories
{
    public class SQLHotelRepository : IHotelRepository
    {
        private static readonly string connectionString = AppDbContext.ConnectionString;

        public IEnumerable<Hotel> AllHotels()
        {
            List<Hotel> allHotels = new List<Hotel>();
            string query = "Select * from Hotels";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Hotel hotel = new Hotel();

                    hotel.HotelId = int.Parse(dataTable.Rows[i]["HotelId"].ToString());
                    hotel.Location = dataTable.Rows[i]["Location"].ToString();
                    hotel.Name = dataTable.Rows[i]["Name"].ToString();
                    hotel.ShortDescription = dataTable.Rows[i]["ShortDescription"].ToString();
                    hotel.LongDescription = dataTable.Rows[i]["LongDescription"].ToString();
                    hotel.IsMostPicked = bool.Parse(dataTable.Rows[i]["IsMostPicked"].ToString());
                    hotel.IsBooked = bool.Parse(dataTable.Rows[i]["IsBooked"].ToString());
                    hotel.CategoryId = !int.TryParse(dataTable.Rows[i]["CategoryId"].ToString(), out _) ? 0 : int.Parse(dataTable.Rows[i]["CategoryId"].ToString());
                    hotel.Price = decimal.Parse(dataTable.Rows[i]["Price"].ToString());
                    hotel.ImageUrl = dataTable.Rows[i]["ImageUrl"].ToString();

                    allHotels.Add(hotel);
                }
            }
            return allHotels;
        }

        public Hotel GetHotelById(int hotelId)
        {
            var allHotels = AllHotels();
            return allHotels.FirstOrDefault(h => h.HotelId == hotelId);
        }
    }
}
