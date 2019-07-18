using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ToDo.Database;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models.Todo;

namespace ToDo.API.Controllers
{
    /// <summary>
    /// Контроллер по управлению задачами
    /// </summary>
    [Route("api/todo")]
//    [ApiController]
    public class TodoController : Controller
    {
        private DatabaseContext _context;
        private readonly ITodoInterface _todoService;

        /// <summary/>
        public TodoController(DatabaseContext context, ITodoInterface todoInterface)
        {
            _context = context;
            _todoService = todoInterface;
        }

        /// <summary>
        /// Получение задачи
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<TodoViewModel>> GetTodoItems()
        {
            return await _todoService.GetAll();
        }

        /// <summary>
        /// Получение задачи
        /// </summary>
        /// <param name="guid">Уникальный идентификатор</param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        public async Task<TodoViewModel> GetTodoItem(Guid guid)
        {
            return await _todoService.Get(guid);
        }

        /// <summary>
        /// Добавление задачи
        /// </summary>
        /// <param name="todoItem">Модель задачи</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Guid> AddTodoItem(TodoCreateModel todoItem)
        {
            return await _todoService.Create(todoItem);
        }

        /// <summary>
        /// Изменение задачи
        /// </summary>
        /// <param name="guid">Уникальный идентификатор</param>
        /// <param name="todoItem">Модель задачи</param>
        /// <returns></returns>
        [HttpPut("{guid}")]
        public async Task<Guid> EditTodoItem(Guid guid, TodoEditModel todoItem)
        {
            return await _todoService.Update(guid, todoItem);
        }


        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="guid">Уникальный идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{guid}")]
        public async Task DeleteTodoItem(Guid guid)
        {
            await _todoService.Delete(guid);
        }
    }
}