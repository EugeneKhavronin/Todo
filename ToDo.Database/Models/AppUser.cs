using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ToDo.Database.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        [Required]
        public string Birthday { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Связи между таблицами
        /// </summary>
        public List<TodoItem> Todos { get; set; }
    }
}