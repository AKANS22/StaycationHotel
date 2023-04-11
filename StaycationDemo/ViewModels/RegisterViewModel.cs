using System.ComponentModel.DataAnnotations;

namespace StaycationDemo.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
         ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,16}$",
         ErrorMessage = "Please enter a valid password.")]
        [StringLength(10)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
    }
}
