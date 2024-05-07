using Microsoft.EntityFrameworkCore;
using SimpleWebSocket.Hubs;
using SimpleWebSocket.Models;

namespace SimpleWebSocket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();

            builder.Services.AddDbContext<SignalRContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapHub<EmpsHub>("/emp");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
