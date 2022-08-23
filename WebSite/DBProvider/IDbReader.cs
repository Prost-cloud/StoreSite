using System;
using System.Collections.Generic;
using WebSite.DBModels;

namespace WebSite.DBProvider
{
    public interface IDbReader : IDisposable
    {
        List<Product> GetAllProducts();
        List<Product> GetProducts(Func<Product, bool> search);
        List<Product> GetAllProductsWithDeleted();
        List<Product> GetProductsWithDeleted(Func<Product, bool> search);
    }
}