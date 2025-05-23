using E_Pet.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Pet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? 
                                  "Data Source=e-pet.db"));

           
            builder.Services.AddRazorPages();

            var app = builder.Build();

           
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    // Veritabanını oluştur veya güncelle
                    context.Database.EnsureCreated();
                    
                   
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Veritabanı oluşturulurken bir hata oluştu.");
                }
            }

            // HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}