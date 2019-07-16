using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Models.Account
{
    public class LoginModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Запомнить пользователя
        /// </summary>
        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Возврат url
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}