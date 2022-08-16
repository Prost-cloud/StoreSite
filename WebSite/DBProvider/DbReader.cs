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

        public List<Products> GetAllProducts()
        {
            return sqliteDbContext.Products.Where(x => !x.IsDeleted).ToList();
        }

        public List<Products> GetAllProductsWithDeleted()
        {
            return sqliteDbContext.Products.ToList();
        }

        public List<Products> GetProducts(Func<Products, bool> search)
        {
            return sqliteDbContext.Products.Where(search).Where(x => !x.IsDeleted).ToList();
        }

        public List<Products> GetProductsWithDeleted(Func<Products, bool> search)
        {
            return sqliteDbContext.Products.Where(search).ToList();
        }
        
        public void Dispose()
        {
            sqliteDbContext.Dispose();
        }
    }
}
