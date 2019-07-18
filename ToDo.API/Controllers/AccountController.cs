using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDo.Database.Models;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models.Account;

namespace ToDo.API.Controllers
{
    /// <summary>
    /// Контроллер по управлению аккаунтом
    /// </summary>
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountInterface _accountInterface;
        private readonly SignInManager<AppUser> _signInManager;

        /// <summary/>
        public AccountController(IAccountInterface accountInterface, SignInManager<AppUser> signInManager)
        {
            _accountInterface = accountInterface;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Получение пользователей
        /// </summary>
        /// <returns></returns>
        [Route("GetUsers")]
        [HttpGet]
        public async Task<IEnumerable<AccountViewModel>> GetUsers()
        {
            return await _accountInterface.GetUsers();
        }

        /// <summary>
        /// Логин
        /// </summary>
        /// <param name="model">Модель логина</param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<LoginModel> Login(LoginModel model)
        {
            return await _accountInterface.Login(model);
        }

        /// <summary>
        /// Выход
        /// </summary>
        /// <returns></returns>
        [Route("LogOff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Logoff()
        {
            await _accountInterface.Logoff();
        }
    }
}