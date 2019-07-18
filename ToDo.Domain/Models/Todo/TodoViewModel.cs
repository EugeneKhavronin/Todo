using System;

namespace ToDo.Domain.Models.Todo
{
    public class TodoViewModel
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public bool IsComplete { get; set; }
    }
}