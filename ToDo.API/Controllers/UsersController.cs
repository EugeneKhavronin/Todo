using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Database.Models;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models.User;

namespace ToDo.API.Controllers
{
    /// <summary>
    /// Контроллер по управлению пользователем
    /// </summary>
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager, IUserInterface userInterface)
        {
            _userManager = userManager;
            _userInterface = userInterface;
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="model">Модель регистрации</param>
        /// <returns></returns>
        [Route("Register")]
        [HttpPost]
        public async Task<string> Register(UserModel model)
        {
            return await _userInterface.Register(model);
        }

        /// <summary>
        /// Изменение пользователя
        /// </summary>
        /// <param name="id">Уникальный идентификатор</param>
        /// <param name="editModel">Модель пользователя</param>
        /// <returns></returns>
        [Route("Edit")]
        [HttpPost]
        public async Task<string> Edit(string id, UserModel editModel)
        {
            return await _userInterface.Edit(id, editModel);
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя</param>
        /// <returns></returns>
        [Route("Delete")]
        [HttpPost]
        public async Task Delete(string id)
        {
            await _userInterface.Delete(id);
        }
    }
}