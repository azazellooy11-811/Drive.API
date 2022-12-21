using Drive.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drive.Database
{
    public class DriveContext : DbContext
    {
        public DriveContext(DbContextOptions<DriveContext> options)
            : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Badges> Badges { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                    .HasMany(c => c.ErrorUsers)
                    .WithMany(s => s.ErrorQuestion)
                    .UsingEntity(j => j.ToTable("UserErrorQuestions"));
            modelBuilder.Entity<Badges>()
                .HasMany(c => c.BadgesUsers)
                .WithMany(s => s.Badges)
                .UsingEntity(j => j.ToTable("UserBadgesTable"));
        }
    }
}