using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models.Todo;

namespace ToDo.Domain.Interfaces
{
    public interface ITodoInterface
    {
        /// <summary>
        /// Получение задачи
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TodoViewModel>> GetAll();

        /// <summary>
        /// Получение задачи
        /// </summary>
        /// <param name="guid">Уникальный идентификатор</param>
        /// <returns></returns>
        Task<TodoViewModel> Get(Guid guid);

        /// <summary>
        /// Добавление задачи
        /// </summary>
        /// <param name="todoItem">Модель задачи</param>
        /// <returns></returns>
        Task<Guid> Create(TodoCreateModel todoItem);

        /// <summary>
        /// Изменение задачи
        /// </summary>
        /// <param name="guid">Уникальный идентификатор</param>
        /// <param name="todoItem">Модель задачи</param>
        /// <returns></returns>
        Task<Guid> Update(Guid guid, TodoEditModel todoItem);

        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="guid">Уникальный идентификатор</param>
        /// <returns></returns>
        Task Delete(Guid guid);
    }
}