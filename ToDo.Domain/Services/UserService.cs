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
        public async Task<string> Register(UserModel model)
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
            await _userManager.CreateAsync(user);
//            
//            _context.AppUsers.Add(user);
//            await _context.SaveChangesAsync();
//
            return user.Id;
        }

        /// <inheritdoc />
        public async Task<string> Edit(string id, UserModel editModel)
        {
            var user = await _userManager.FindByIdAsync(id);
            var editUser = new AppUser
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                PasswordHash = user.PasswordHash,
                Birthday = user.Birthday,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                SecurityStamp = user.SecurityStamp,
                NormalizedUserName = user.NormalizedUserName,
                NormalizedEmail = user.NormalizedEmail,
                EmailConfirmed = user.EmailConfirmed,
                ConcurrencyStamp = user.ConcurrencyStamp,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnd = user.LockoutEnd,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount,
                PhoneNumber = user.PhoneNumber
            };
            await _userManager.UpdateAsync(editUser);
            return editUser.Id;
        }

        /// <inheritdoc />
        public async Task Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
        }
    }
}