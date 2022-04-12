using Drive.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drive.Database
{
    public class DriveContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<File> Files { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=Drive;Username=postgres;Password=postgres;");
        }
    }
}