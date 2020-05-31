using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Hosting;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Middleware;
using WebStore.Infrastructure.Services;

namespace WebStore
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(opt =>
                {   
                    //opt.Filters.Add<>()
                    //opt.Conventions
                    //opt.Conventions.Add();
                })
               .AddRazorRuntimeCompilation();

            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseMiddleware<CultureMiddleware>();
            var supported_cultures = new []
            {
                new CultureInfo("ru"),
                new CultureInfo("en"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru"),
                SupportedCultures = supported_cultures,
                SupportedUICultures = supported_cultures
            });

            app.UseWelcomePage("/MVC");

            //app.Use(async (context, next) =>
            //{
            //    Debug.WriteLine($"Request to {context.Request.Path}");
            //    await next(); // Можем прервать конвейер не вызывая await next()
            //    // постобработка
            //});
            //app.UseMiddleware<>()

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
