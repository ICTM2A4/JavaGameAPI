using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JavaGameAPI.Models;

namespace JavaGameAPI.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAchievement>()
                .HasKey(ua => new { ua.UserID, ua.AchievementID});
            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAchievements)
                .HasForeignKey(ua => ua.UserID);
            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.Achievement)
                .WithMany(a => a.UserAchievements)
                .HasForeignKey(ua => ua.AchievementID);
        }

        public DbSet<Level> Level { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Score> Score { get; set; }

        public DbSet<Achievement> Achievement { get; set; }

        public DbSet<UserAchievement> UserAchievement { get; set; }
    }
}
