using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;
using System.Security.Claims;
using WebApplicationDemo.Data;
using WebApplicationDemo.Interfaces;
using WebApplicationDemo.Models;
using WebApplicationDemo.Repository;
using WebApplicationDemo.Services;
namespace WebApplicationDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ITPQ3Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<ITraineeService, TraineeService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddAuthentication().AddCookie();
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
                options.AddPolicy("SupervisorOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Supervisor"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("Hello World from my first custom middleware\n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("Returning from my first custom middleware\n");
            //});

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World from my second custom middleware\n");
            //});

            app.Run();
        }
    }
}
