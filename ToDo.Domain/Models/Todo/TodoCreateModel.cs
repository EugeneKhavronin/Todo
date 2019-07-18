using System;

namespace ToDo.Domain.Models.Todo
{
    public class TodoCreateModel
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        private Guid Guid { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public bool IsComplete { get; set; }

        public TodoCreateModel()
        {
        }

        public TodoCreateModel(string name, bool isComplete)
        {
            Guid = Guid.NewGuid();
            Name = name;
            IsComplete = isComplete;
        }

        public TodoCreateModel(Guid guid, string name, bool isComplete)
        {
            Guid = guid;
            Name = name;
            IsComplete = isComplete;
        }
    }
}