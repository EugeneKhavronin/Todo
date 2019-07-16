using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

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
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        public string Password { get; set; }

        //public List<TodoItem> Todos { get; set; }
    }
}