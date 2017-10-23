using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Identity2Example.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Требуется поле {0}.")]
        [Display(Name = "Адрес электронной почты")]
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
        [Required(ErrorMessage = "Требуется поле {0}.")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Требуется поле {0}.")]
        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Запомнить браузер?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Требуется поле {0}.")]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Требуется поле {0}.")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Требуется поле {0}.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Требуется поле {0}.")]
        [Display(Name = "Логин")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Требуется поле {0}.")]
        [EmailAddress(ErrorMessage = "Пожалуйста, введите корректный адрес электронной почты.")]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Требуется поле {0}.")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        // Необязательные поля
        [Display(Name = "Имя")]
        [StringLength(50, ErrorMessage = "Значение {0} должно содержать не более {1} символов.")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(50, ErrorMessage = "Значение {0} должно содержать не более {1} символов.")]
        public string LastName { get; set; }

        [Display(Name = "Пол")]
        public UserGender Gender { get; set; }

        [Display(Name = "О себе")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не более {1} символов.")]
        public string About { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Требуется поле {0}.")]
        [EmailAddress(ErrorMessage = "Пожалуйста, введите корректный адрес электронной почты.")]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Требуется поле {0}.")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Требуется поле {0}.")]
        [EmailAddress(ErrorMessage = "Пожалуйста, введите корректный адрес электронной почты.")]
        [Display(Name = "Почта")]
        public string Email { get; set; }
    }
}
