using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Player_Dashboard
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<GameplayStat> GameplayStats { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<GameplayStat>()
                .HasOne(gs => gs.Player)
                .WithMany(p => p.GameplayStats)
                .HasForeignKey(gs => gs.PlayerId);
        }
    }
}
