using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;
using Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace DAL
{
    public class DiagramsDbContext : DbContext
    {
        // this is bad practice, but for easy startup it stays here, you can change the string
        private const string _connectionString = "server=localhost; port=3306; database=diagram; user=diagram_usr; password=password; Persist Security Info=False; Connect Timeout=300";

        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Diagram> Diagrams { get; set; }

        public DbSet<UserDiagram> UserDiagrams { get; set; }

        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql(_connectionString, new MySqlServerVersion(new System.Version()))
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
