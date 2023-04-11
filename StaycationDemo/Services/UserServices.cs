using StaycationDemo.Models;
using StaycationDemo.ViewModels;
using System.Threading.Tasks;
using System;
using StaycationDemo.Models.Abstractions;
using StaycationDemo.Helpers;

namespace StaycationDemo.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IUtilities _utilities;
        public UserServices(IUserRepository userRepository, IUtilities utilities)
        {
            _userRepository = userRepository;
            _utilities = utilities;
        }

        public User Login(LoginViewModel model)
        {
            string passWord = _utilities.HashPassword(model.Password); 
            User user = _userRepository.GetUserByEmailAndPassword(model.Email, passWord);
            //User user = _userRepository.GetUserByEmailAndPassword(model.Email, model.Password);
            return user;
        }

        public bool Register(RegisterViewModel model)
        {
            string password = _utilities.HashPassword(model.Password);

            User user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = password,
            };

            bool registered = _userRepository.SaveCustomer(user);

            return registered;
        }
    }
}
