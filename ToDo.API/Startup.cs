﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Identity.UI;
using System.Reflection;
using System.IO;
using ToDo.Database.Models;
using ToDo.Database;
using ToDo.Domain;
using ToDo.Domain.Models.User;

namespace ToDo.API
{
    public class Startup
    {
        //Конфигурация приложения
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //Регистрация сервисов
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDomain();
            //postgresql
            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("ToDo.API")));
            //Настройки Identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<DatabaseContext>();

            services.Configure<IdentityOptions>(options =>
            {
                //Настройки пароля
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Настройки блокировки
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });

            // Настройки куки
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            // Swagger генератор
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "ToDo.API", Version = "v1"});
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        //Подключение расширений 
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger(); //swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo.API V1");
                c.RoutePrefix = string.Empty;
            });
        }

        //конфиг (appsettings.json) v
        //Fluent Api v
        //коменты v
        //Postgres в Docker (Postgres в DockerCompose) v


        //id => Guid
        //identity 
        //user: id, login, password, name, surname, birthday, telephoneNumber
        //LoginModel: login, password
        //RegisterModel: login, password, name, surname, birthday, telephoneNumber
        //TodoItem: userId
        //

        //UserController: Register/Edit/Delete
        //AccountController: SignIn/SignOut v

        // git установить, Github аккаунт, залить проект v
        // -Areas v
        // -pages v
        // У тебя остается только Controllers, Migrations, Models, Views c одним файлом Index.cshtml v
        // Почитай про SPA (Single Page Application)
        // Все возвращаемые значения должны быть в формате Task<данные>:  v
        // если создание или изменение, то id элемента 
        // если получение, то сама модель, либо List моделей 
        // если удаление, то просто Task
        // 
        // Комменты везде
        // AutoMapper почитать        
    }
}