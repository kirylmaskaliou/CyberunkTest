using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CyberpunkBackend.Data;

namespace CyberpunkBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register services
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ContactsContext>(options =>
                options.UseSqlite("Data Source=Data/contacts.db"));

            var app = builder.Build();

            // Middleware pipeline
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();
            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
