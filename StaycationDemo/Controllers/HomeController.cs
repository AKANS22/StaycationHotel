using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StaycationDemo.Models.Abstractions;
using StaycationDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StaycationDemo.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
		private readonly IHotelRepository _hotelRepository;
		private readonly ICategoryRepository _categoryRepository;

		public HomeController(IHotelRepository hotelRepository, ICategoryRepository categoryRepository)
		{
			_hotelRepository = hotelRepository;
			_categoryRepository = categoryRepository;
		}

		public IActionResult Index()
        {
			HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.AllCategories = _categoryRepository.AllCategories();
            homeViewModel.Hotels = _hotelRepository.AllHotels();
			return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var hotel = _hotelRepository.GetHotelById(id);
            if (hotel == null) { return NotFound(); }
            return View(hotel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
