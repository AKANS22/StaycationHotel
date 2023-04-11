using StaycationDemo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StaycationDemo.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Please enter your Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Please enter your Password")]
		[StringLength(10)]
		public string Password { get; set; }

	}
}
