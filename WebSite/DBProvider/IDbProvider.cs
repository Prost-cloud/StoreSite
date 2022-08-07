using System;
using System.Collections.Generic;
using WebSite.DBModels;

namespace WebSite.DBProvider
{
    public interface IDbProvider
    {
        List<Products> GetAllProducts();
        List<Products> GetAllProducts(Func<Products, bool> search);
    }
}