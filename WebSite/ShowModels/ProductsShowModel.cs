using System.Collections.Generic;
using WebSite.DBModels;

namespace WebSite.ShowModels
{
    public class ProductsShowModel
    {
        public readonly List<Products> ProductsList;
        public readonly int ProductsCount;
        public int CurrentPage;

        public int ProductsPerPage => 4;
        public int PageCount => ProductsCount / ProductsPerPage +
            (ProductsCount % ProductsPerPage == 0 ? 0 : 1);
        public bool IsPagesNeeded => ProductsCount > ProductsPerPage;
        public PageMap GetPageMap => getPageMap();

        public ProductsShowModel(List<Products> products) : this(products, 0) { }

        public ProductsShowModel(List<Products> products, int currentPage)
        {
            ProductsList = products;
            ProductsCount = products.Count;
            if (currentPage > PageCount - 1 || currentPage < 0)
            {
                CurrentPage = currentPage < 0 ? 0 : PageCount;
            }
            else
            {
                CurrentPage = currentPage;
            }
        }

        private PageMap getPageMap()
        {
            int pageFrom = 0;
            int pageTo = 0;

            if (CurrentPage <= 4)
            {
                if (PageCount < 8)
                {
                    pageFrom = 2;
                    pageTo = PageCount - 1;
                }

                if (PageCount > 8)
                {
                    pageFrom = 2;
                    pageTo = PageCount - 1;
                }
            }
            else if (CurrentPage > 4)
            {
                pageFrom = CurrentPage - 2;
                if (CurrentPage+2 > PageCount - 1)
                {
                    pageTo = PageCount - 1;
                }
                else
                {
                    pageTo = CurrentPage + 2;
                }
            }

            return new PageMap() { PageFrom = pageFrom, PageTo = pageTo };
        }
    }
}
