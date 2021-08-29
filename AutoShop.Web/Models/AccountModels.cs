using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Web.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Обов'язкове поле")]
        [EmailAddress(ErrorMessage = "Не корекна пошта")]
        public string Email { get; set; }

        //
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Invalid password")]
        public string Password { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Обов'язкове поле")]
        [EmailAddress(ErrorMessage = "Не корекна пошта")]
        public string Email { get; set; }

        //
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Invalid password")]
        public string Password { get; set; }
    }
}
