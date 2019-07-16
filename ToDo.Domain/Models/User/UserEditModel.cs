using Microsoft.AspNetCore.Identity;

namespace ToDo.Domain.Models.User
{
    public class UserEditModel : IdentityUser
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}