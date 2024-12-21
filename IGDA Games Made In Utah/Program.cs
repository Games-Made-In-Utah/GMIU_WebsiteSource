using IGDAGamesMadeInUtah.Services;
using Microsoft.AspNetCore.Mvc;

namespace IGDA_Games_Made_In_Utah
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    // Configure JSON serialization options
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

            // Register the EventScraper service
            builder.Services.AddScoped<IEventScraper, EventScraper>();

            // Add CORS if needed
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocal",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable CORS
            app.UseCors("AllowLocal");

            app.UseAuthorization();

            // Map controllers
            app.MapControllers(); // Add this line to ensure API controllers are mapped
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}