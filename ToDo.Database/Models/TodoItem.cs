using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

//Модель задачи
namespace ToDo.Database.Models
{
    public class TodoItem
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        [Key]
        public Guid Guid { get; set; } 

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public bool IsComplete { get; set; }


        //[ForeignKey("AppUser")]
        //public Guid UserId { get; set; }
        //public AppUser TodoUser { get; set; }
    }
}