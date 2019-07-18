namespace ToDo.Domain.Models.Todo
{
    public class TodoEditModel
    {
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public bool IsComplete { get; set; }


        public TodoEditModel()
        {
        }

        public TodoEditModel(string name, bool isComplete)
        {
            Name = name;
            IsComplete = isComplete;
        }
    }
}