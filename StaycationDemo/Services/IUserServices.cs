using StaycationDemo.Models;
using StaycationDemo.ViewModels;
using System.Threading.Tasks;

namespace StaycationDemo.Services
{
    public interface IUserServices
    {
        User Login(LoginViewModel model);
        bool Register(RegisterViewModel model);
    }
}