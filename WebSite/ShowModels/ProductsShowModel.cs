using System.Collections.Generic;
using WebSite.DBModels;

namespace WebSite.ShowModels
{
    public class ProductsShowModel
    {
        public List<Products> ProductsList { get; private set; }
        public int ProductsCount { get; private set; }

    }
}
