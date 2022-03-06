using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class DiagramsDbContext : DbContext
    {
        private const string _connectionString = "Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database=Diagrams;Trusted_Connection=True;";

        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Diagram> Diagrams { get; set; }

        public DbSet<UserDiagram> UserDiagrams { get; set; }

        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString)
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDiagram>()
                .HasKey(bc => new { bc.UserId, bc.DiagramId });

            modelBuilder.Entity<UserDiagram>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.Diagrams)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserDiagram>()
                .HasOne(bc => bc.Diagram)
                .WithMany(c => c.Users)
                .HasForeignKey(bc => bc.DiagramId);

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
