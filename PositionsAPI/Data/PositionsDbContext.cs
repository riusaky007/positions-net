using Microsoft.EntityFrameworkCore;
using PositionsAPI.Models;

namespace PositionsAPI.Data
{
    public class PositionsDbContext : DbContext
    {
        public PositionsDbContext(DbContextOptions<PositionsDbContext> options) : base(options) { }
        public DbSet<Position> Positions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>()
                .Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Position>()
                .Property(p => p.Description)
                .HasMaxLength(1000)
                .IsRequired();

            modelBuilder.Entity<Position>()
                .Property(p => p.Location)
                .IsRequired();

            modelBuilder.Entity<Position>()
                .Property(p => p.Status)
                .IsRequired();

            modelBuilder.Entity<Position>()
                .Property(p => p.RecruiterId)
                .IsRequired();

            modelBuilder.Entity<Position>()
                .Property(p => p.DepartmentId)
                .IsRequired();

            modelBuilder.Entity<Position>()
                .Property(p => p.Budget)
                .IsRequired();
        }
    }
}
