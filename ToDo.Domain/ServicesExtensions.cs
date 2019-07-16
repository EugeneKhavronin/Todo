using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Services;

namespace ToDo.Domain
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IAccountInterface, AccountService>();
            services.AddScoped<ITodoInterface, TodoService>();
            services.AddScoped<IUserInterface, UserService>();

            return services;
        }
    }
}