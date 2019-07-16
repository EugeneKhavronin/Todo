using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ToDo.Database;
using ToDo.Database.Models;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models.User;

namespace ToDo.Domain.Services
{
    public class UserService : IUserInterface
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserService(DatabaseContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <inheritdoc />
        public async Task<string> Register(UserRegisterModel model)
        {
            var user = new AppUser
            {
                UserName = model.Login,
                Login = model.Login,
                Password = model.Password,
                Name = model.Name,
                Surname = model.Surname,
                Birthday = model.Birthday,
                PhoneNumber = model.PhoneNumber
            };
            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        /// <inheritdoc />
        public async Task<string> Edit(string id, UserEditModel editModel)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.Id = editModel.Id;
            user.Login = editModel.Login;
            user.Password = editModel.Password;
            user.PasswordHash = editModel.PasswordHash;
            user.Birthday = editModel.Birthday;
            user.Name = editModel.Name;
            user.Surname = editModel.Surname;
            user.Email = editModel.Email;
            user.PhoneNumber = editModel.PhoneNumber;
            _context.AppUsers.Update(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        /// <inheritdoc />
        public async Task Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
        }
    }
}