using ASAPMethodology.Business.DependencyResolvers.Autofac;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;

namespace ASAPMethodology.MvcWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new BusinessModule());
                builder.RegisterModule(new ValidationModule());
                builder.RegisterModule(new AutoMapperModule());
            });

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddFluentValidationAutoValidation();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}