using HomeWorkMVC1.DAL.Context;
using HomeWorkMVC1.Entities.Base.Interfaces;
using HomeWorkMVC1.Infrastructure.InMemory;
using HomeWorkMVC1.Infrastructure.Interfaces;
using HomeWorkMVC1.Infrastructure.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWorkMVC1
{
    public class Startup
    {
        /// <summary>
        /// Добавляем свойство для доступа к конфигурации
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Добавляем новый конструктор, принимающий интерфейс IConfiguration
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
            //Добавляем сервисы, необходимые для mvc
            services.AddMvc();

            services.AddDbContext<HomeWorkMVC1Context>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));


            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();

            //Добавляем разрешение зависимости
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();

            // removed due to migration to SQL
            //services.AddSingleton<IProductData, InMemoryProductData>();

            services.AddTransient<IProductData, SqlProductData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Добавляем расширение для использования статических файлов, т.к. appsettings.json - это статический файл
            app.UseStaticFiles();

            //Добавляем обработку запросов в mvc-формате
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "Employee",
                //    template: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
