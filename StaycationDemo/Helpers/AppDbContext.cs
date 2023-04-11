using Microsoft.AspNetCore.Connections;

namespace StaycationDemo.Helpers
{
    public class AppDbContext
    {
        public static string ConnectionString { get;} = "Data Source=desktop-jd0t90h;Initial Catalog=Staycation;Integrated Security=True";
    }
}
