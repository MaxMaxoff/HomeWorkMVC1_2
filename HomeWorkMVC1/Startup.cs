using System;
using HomeWorkMVC1.DAL.Context;
using HomeWorkMVC1.Domain.Entities;
using HomeWorkMVC1.Entities.Base.Interfaces;
using HomeWorkMVC1.Infrastructure.Implementations;
using HomeWorkMVC1.Infrastructure.Implementations.Sql;
using HomeWorkMVC1.Infrastructure.InMemory;
using HomeWorkMVC1.Infrastructure.Interfaces;
using HomeWorkMVC1.Infrastructure.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWorkMVC1
{
    public class Startup
    {
        /// <summary>
        /// Property Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Default Ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC services
            services.AddMvc();

            // Add user data/dependences
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();

            // Add product data and connection to DB
            services.AddTransient<IProductData, SqlProductData>();
            services.AddTransient<IOrdersService, SqlOrdersService>();

            services.AddDbContext<HomeWorkMVC1Context>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            // Add identity services
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<HomeWorkMVC1Context>()
                .AddDefaultTokenProviders();

            // default configuration options for identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequiredLength = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            // default configuration options for Cookie
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);

                // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LoginPath = "/Account/Login";

                // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.LogoutPath = "/Account/Logout";

                // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            //Настройки для корзины
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICartService, CookieCartService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add using static files, in case of appsettings.json is static
            app.UseStaticFiles();

            // Add using Welcome page
            app.UseWelcomePage("/welcome");

            // Add using authentication
            app.UseAuthentication();

            // Add MVC routes
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name : "areas",
                    template : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
