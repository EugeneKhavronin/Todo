using System;
using System.Collections.Generic;
using ToDo.Domain.Interfaces;
using ToDo.Database;
using System.Threading.Tasks;
using ToDo.Database.Models;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Models;
using ToDo.Domain.Models.Todo;

namespace ToDo.Domain.Services
{
    class TodoService : ITodoInterface
    {
        private readonly DatabaseContext _context;

        public TodoService(DatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TodoViewModel>> GetAll()
        {
            var result = await _context.TodoItems.ToListAsync();
            List<TodoViewModel> results = new List<TodoViewModel>();
            foreach (var todoItem in result)
            {
                var todoItemModel = new TodoViewModel()
                {
                    Guid = todoItem.Guid,
                    Name = todoItem.Name,
                    IsComplete = todoItem.IsComplete
                };
                results.Add(todoItemModel);
            }

            return results;
        }

        /// <inheritdoc />
        public async Task<TodoViewModel> Get(Guid todoGuid)
        {
            var todoItem = await _context.TodoItems.FindAsync(todoGuid);
            var todoGetModel = new TodoViewModel
            {
                Guid = todoItem.Guid,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
            return todoGetModel;
        }

        /// <inheritdoc />
        public async Task<Guid> Create(TodoCreateModel todoItem)
        {
            var createModel = new TodoItem
            {
                Guid = Guid.NewGuid(),
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
            _context.TodoItems.Add(createModel);
            await _context.SaveChangesAsync();
            return createModel.Guid;
        }

        /// <inheritdoc />
        public async Task<Guid> Update(Guid todoGuid, TodoEditModel todoEditItem)
        {
            var todoItem = await _context.TodoItems.FindAsync(todoGuid);
            todoItem.Name = todoEditItem.Name;
            todoItem.IsComplete = todoEditItem.IsComplete;
            _context.TodoItems.Update(todoItem);
            await _context.SaveChangesAsync();
            return todoItem.Guid;
        }

        /// <inheritdoc />
        public async Task Delete(Guid todoGuid)
        {
            var todoItem = await _context.TodoItems.FindAsync(todoGuid);
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
        }
    }
}