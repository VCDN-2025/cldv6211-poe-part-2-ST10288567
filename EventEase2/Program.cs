using EventEase2.Data;
using Microsoft.EntityFrameworkCore;

namespace EventEase2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Already includes:
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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




//Reference List for code:

//Date: 13 May 2025

//Author: Darsh Somayi

//Sourced: Harrison, W., 2022. Azure for Developers: Implement rich Azure PaaS ecosystems using containers, serverless services, and more. Packt Publishing.

