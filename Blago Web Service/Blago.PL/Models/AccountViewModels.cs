using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blago.PL.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email обязательное поле.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязательное поле.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "'Имя' обязательное поле.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "'Фамилия' обязательное поле.")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "'Пол' обязательное поле.")]
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "'Дата рождения' обязательное поле.")]
        public System.DateTime DateOfBirth { get; set; }
        public string Telegram { get; set; }
        [Required(ErrorMessage = "'Страна' обязательное поле.")]
        public string Country { get; set; }
        public System.DateTime DateRegister { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "'Номер телефона' обязательное поле.")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Referal { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
