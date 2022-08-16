using System;
using System.Collections.Generic;
using WebSite.DBModels;

namespace WebSite.DBProvider
{
    public interface IDbReader : IDisposable
    {
        List<Products> GetAllProducts();
        List<Products> GetProducts(Func<Products, bool> search);
        List<Products> GetAllProductsWithDeleted();
        List<Products> GetProductsWithDeleted(Func<Products, bool> search);
    }
}