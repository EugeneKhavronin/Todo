using System.Threading.Tasks;
using ToDo.Domain.Models.User;

namespace ToDo.Domain.Interfaces
{
    public interface IUserInterface
    {
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="model">Модель регистрации</param>
        /// <returns></returns>
        Task<string> Register(UserModel model);

        /// <summary>
        /// Изменение пользователя
        /// </summary>
        /// <param name="id">Уникальный идентификатор</param>
        /// <param name="editModel">Модель пользователя</param>
        /// <returns></returns>
        Task<string> Edit(string id, UserModel editModel);

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя</param>
        /// <returns></returns>
        Task Delete(string id);
    }
}