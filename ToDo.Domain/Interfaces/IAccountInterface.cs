using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Database.Models;
using ToDo.Domain.Models.Account;

namespace ToDo.Domain.Interfaces
{
    public interface IAccountInterface
    {
        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AccountViewModel>> GetUsers();

        /// <summary>
        /// Логин
        /// </summary>
        /// <param name="model">Модель логина</param>
        /// <returns></returns>
        Task<LoginModel> Login(LoginModel model);

        /// <summary>
        /// Выход
        /// </summary>
        /// <returns></returns>
        Task Logoff();
    }
}