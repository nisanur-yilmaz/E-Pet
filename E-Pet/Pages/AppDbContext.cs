using Microsoft.EntityFrameworkCore;

namespace E_Pet.Models
{
    public class AppDbContext : DbContext
    {
      
        public DbSet<Animals> Animals { get; set; }

      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Primary key tanımlaması
            modelBuilder.Entity<Animals>()
                .HasKey(a => a.Id);
            

            modelBuilder.Entity<Animals>()
                .Property(a => a.Type)
                .IsRequired();

            modelBuilder.Entity<Animals>()
                .Property(a => a.Gender)
                .IsRequired();

            modelBuilder.Entity<Animals>()
                .Property(a => a.ImgUrl)
                .IsRequired();
        }
    }

    // Animal model sınıfı
    public class Animals
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string ImgUrl { get; set; }
        public string? VaccineStatus { get; set; } // bool olarak değiştirildi
    }
}