using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSite.DBModels;

namespace WebSite.DBProvider
{
    public class DbReader : IDbReader, IDisposable
    {
        private SqliteDbContext sqliteDbContext;

        public DbReader()
        {
            sqliteDbContext = new SqliteDbContext();
            sqliteDbContext.Database.EnsureCreated();
        }

        public List<Product> GetAllProducts()
        {
            return sqliteDbContext.Products.Where(x => !x.IsDeleted).ToList();
        }

        public List<Product> GetAllProductsWithDeleted()
        {
            return sqliteDbContext.Products.ToList();
        }

        public List<Product> GetProducts(Func<Product, bool> search)
        {
            return sqliteDbContext.Products.Where(search).Where(x => !x.IsDeleted).ToList();
        }

        public List<Product> GetProductsWithDeleted(Func<Product, bool> search)
        {
            return sqliteDbContext.Products.Where(search).ToList();
        }
        
        public void Dispose()
        {
            sqliteDbContext.Dispose();
        }
    }
}
