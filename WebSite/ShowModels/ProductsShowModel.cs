using System.Collections.Generic;
using WebSite.DBModels;

namespace WebSite.ShowModels
{
    public class ProductsShowModel
    {
        public readonly List<Products> ProductsList;
        public readonly int ProductsCount;
        public int CurrentPage;

        public int ProductsPerPage => 1;
        public int PageCount => ProductsCount / ProductsPerPage +
            (ProductsCount % ProductsPerPage == 0 ? 0 : 1);
        public bool IsPagesNeeded => ProductsCount > ProductsPerPage;
        public PageMap GetCurrentPageMap => GetPageMap();

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

        // TODO: Remove magic integers 
        private PageMap GetPageMap()
        {
            int pageFrom = 0;
            int pageTo = 0;

            if (CurrentPage < 4)
            {
                pageFrom = 2;
                if (PageCount < 8)
                {
                    pageTo = PageCount - 1;
                }

                if (PageCount >= 8)
                {
                    if (CurrentPage > 3)
                    {
                        pageTo = CurrentPage + 4;
                    }
                    else
                    {
                        pageTo = 6;
                    }
                }
            }
            else if (CurrentPage >= 4)
            {
                pageFrom = CurrentPage - 1;
                if (CurrentPage + 2 > PageCount - 1)
                {
                    pageTo = PageCount - 1;
                }
                else
                {
                    pageTo = CurrentPage + 4;
                }
            }

            bool isNextPageNeeded = false, isPreviousPageNeeded = false;
            int previousPage = 0, nextPage = 0;

            if (CurrentPage >= 4)
            {
                isPreviousPageNeeded = true;
                previousPage = CurrentPage - 2;
            }

            if (PageCount > 7)
            {
                if (PageCount - CurrentPage - 2 >= 3)
                {
                    isNextPageNeeded = true;
                    if (CurrentPage > 3)
                    {
                        nextPage = CurrentPage + 5;
                    }
                    else
                    {
                        nextPage = 7;
                    }
                }
            }
            return new PageMap() { PageFrom = pageFrom, PageTo = pageTo, IsNextNeeded = isNextPageNeeded, IsPreviousNeeded = isPreviousPageNeeded, PreviousPage = previousPage, NextPage = nextPage };
        }
    }
}
