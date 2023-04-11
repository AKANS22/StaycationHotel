using System.Collections.Generic;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace StaycationDemo.Models.Abstractions
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> AllHotels();
        Hotel GetHotelById(int hotelId);
    }
}
