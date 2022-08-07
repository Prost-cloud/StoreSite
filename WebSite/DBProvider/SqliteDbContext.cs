using WebSite.DBModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebSite.DBProvider
{
    internal class SqliteDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

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
            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(k => k.guid);
                entity.HasIndex(k => k.Name);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}