using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDo.Database;
using ToDo.Database.Models;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models.Account;

namespace ToDo.Domain.Services
{
    public class AccountService : IAccountInterface
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly DatabaseContext _context;

        /// <summary/>
        public AccountService(SignInManager<AppUser> signInManager, DatabaseContext context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<AccountGetModel>> GetUsers()
        {
            var result = await _context.AppUsers.ToListAsync();
            List<AccountGetModel> results = new List<AccountGetModel>();
            foreach (var appUser in result)
            {
                var accountModel = new AccountGetModel()
                {
                    Id = appUser.Id,
                    Name = appUser.Name,
                    Surname = appUser.Surname,
                    Birthday = appUser.Birthday,
                    Login = appUser.Login,
                    Password = appUser.Password,
                    Email = appUser.Email,
                    PhoneNumber = appUser.PhoneNumber
                };
                results.Add(accountModel);
            }

            return results;
        }

        /// <inheritdoc />
        public async Task<LoginModel> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
            return model;
        }

        /// <inheritdoc />
        public async Task Logoff()
        {
            await _signInManager.SignOutAsync();
        }
    }
}