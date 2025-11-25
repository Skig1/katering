using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using SiteCatering.Domain;
using SiteCatering.Domain.Repositories.Abstract;
using SiteCatering.Domain.Repositories.EntityFramework;
using SiteCatering.Infrastructure;

namespace SiteCatering
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
           

            //Подключение appsettings.json
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            //Project в обьектную форму
            IConfiguration configuration = configurationBuilder.Build();
            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

            // Подключаем базу данных
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(config.DataBase.ConnectionString)
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

            builder.Services.AddTransient<IDishRepository, EFDishRepository>();
            builder.Services.AddTransient<DataManager>();


            //Настройка identity систему
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            
            //Auth cockie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "MyCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/admin/accessdenied";
                options.SlidingExpiration = true;
            });

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Опционально
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; // Обязательно для использования без согласия пользователя
            });

            //Функционал контроллеров
            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

         
            //Статичные файлы
            app.UseStaticFiles();


            //Маршрутизация
            app.UseRouting(); 
            app.UseSession();


            app.MapControllerRoute("default", "{Controller=Home}/{action=Index}/{id?}");
            
            //Аутонтификация и авторизация
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            await app.RunAsync();
        }
    }
}
