using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WinesStockContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wine> Wines { get; set; }

        public DbSet<WineTasting> WineTastings { get; set; }
        public DbSet<WineTastingWine> WineTastingWines { get; set; }

        public WinesStockContext(DbContextOptions<WinesStockContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WineTastingWine>()
                .HasKey(wtw => new { wtw.WineId, wtw.WineTastingId });

            modelBuilder.Entity<WineTastingWine>()
                .HasOne(wtw => wtw.Wine)
                .WithMany(w => w.WineTastingWines)
                .HasForeignKey(wtw => wtw.WineId);

            modelBuilder.Entity<WineTastingWine>()
                .HasOne(wtw => wtw.WineTasting)
                .WithMany(wt => wt.WineTastingWines )
                .HasForeignKey(wtw => wtw.WineTastingId);
        }
    }
}
