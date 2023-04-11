using System.Collections.Generic;
using System.Threading.Tasks;

namespace StaycationDemo.Models.Abstractions
{
    public interface IUserRepository
    {
        IEnumerable<User> AllUsers();
        User GetUserByEmailAndPassword(string email, string password);
        bool SaveCustomer(User user);

    }
}
