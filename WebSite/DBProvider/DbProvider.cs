using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSite.DBModels;

namespace WebSite.DBProvider
{
    public class DbProvider : IDbProvider
    {
        private SqliteDbContext sqliteDbContext;

        public DbProvider()
        {
            sqliteDbContext = new SqliteDbContext();
            sqliteDbContext.Database.EnsureCreated();
        }

        public List<Products> GetAllProducts()
        {
            return sqliteDbContext.Products.ToList();
        }

        public List<Products> GetAllProducts(Func<Products, bool> search)
        {
            return sqliteDbContext.Products.Where(search).ToList();
        }
    }
}
