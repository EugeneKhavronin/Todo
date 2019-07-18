using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        /// <summary>
        /// Связи между таблицами
        /// </summary>
        [ForeignKey("AppUser")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Связи между таблицами
        /// </summary>    
        public AppUser TodoUser { get; set; }

        public TodoItem()
        {
        }

        public TodoItem(string name, bool isComplete)
        {
            Guid = Guid.NewGuid();
            Name = name;
            IsComplete = isComplete;
        }

        public TodoItem(Guid guid, string name, bool isComplete)
        {
            Guid = guid;
            Name = name;
            IsComplete = isComplete;
        }
    }
}