using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        #region DbSet
        public DbSet<Worker> Workers { get; set; }
        public DbSet<TeamLeader> TeamLeaders { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Worker>().ToTable("Workers");
            modelBuilder.Entity<TeamLeader>().ToTable("TeamLeaders");

            modelBuilder.Entity<Worker>()
                .HasOne<TeamLeader>(w => w.TeamLeader)
                .WithMany(t => t.Workers)
                .HasForeignKey(s => s.TeamLeaderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TeamLeader>()
                .HasMany<Worker>(t => t.Workers)
                .WithOne(w => w.TeamLeader)
                .HasForeignKey(w => w.TeamLeaderId)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder.EnableAutoHistory(null));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName).AddJsonFile("AppSettings.json");
            var config = configuration.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

    }
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName).AddJsonFile("AppSettings.json");
            var config = configuration.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
