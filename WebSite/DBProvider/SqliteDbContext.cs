using WebSite.DBModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebSite.DBProvider
{
    internal class SqliteDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=sqlitedb.sqlite3", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(k => k.Guid);
                entity.HasIndex(k => k.Name);
            });

            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(k => k.Guid);
                //entity.HasAlternateKey(k => k.RoleId);
                entity.HasIndex(k => k.RoleId);
            });
            modelBuilder.Entity<Role>().Property(k => k.RoleId).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Role>().Property(k => k.RoleId).();

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(k => k.Guid);
                //entity.HasAlternateKey(k => k.UserId);
                entity.HasIndex(k => k.UserId);
            });
            modelBuilder.Entity<User>().Property(k => k.UserId).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}