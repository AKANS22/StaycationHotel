using StaycationDemo.Models;
using System.Collections.Generic;
using System.IO.Pipelines;

namespace StaycationDemo.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Hotel> Hotels { get; set; }
		//public string CurrentCategory { get; set; }
		public IEnumerable<Category> AllCategories { get; set; }
	}
}
