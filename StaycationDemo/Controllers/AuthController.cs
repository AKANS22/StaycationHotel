using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaycationDemo.Models;
using StaycationDemo.Models.Abstractions;
using StaycationDemo.Services;
using StaycationDemo.ViewModels;
using System;
using System.Threading.Tasks;

namespace StaycationDemo.Controllers
{
	public class AuthController : Controller
	{
        private readonly IUserServices _userServices;
		public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult Login()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = _userServices.Login(model);
                    if (user != null)
                    {
                        //HttpContext.Session.SetString("Fullname", $"{user.FirstName} {user.LastName}");
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch(Exception) { throw new Exception("Cannot read from database"); }
            ViewBag.Message = "Email or password is wrong";
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool registered = _userServices.Register(model);
                    if (registered)
                    {
                        return RedirectToAction("Login");
                    }
                }
            }
            catch (Exception) { throw new Exception("Cannot write to database"); }
            return View();
        }
    }
}
