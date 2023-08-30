using Microsoft.EntityFrameworkCore;
using SehirApi.Models;

namespace SehirApi.Data
{
    public class DataContext:DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<City>()
                .HasMany(c => c.Photos)
                .WithOne(c => c.City)
                .HasForeignKey(c => c.CityId);
        }


       
        public DbSet<City> Cities { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
