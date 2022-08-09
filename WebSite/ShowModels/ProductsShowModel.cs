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
        // TODO: Think over making that depended out of chunk page count
        private PageMap GetPageMap()
        {
            const int minimalCurrentPageToCountLowerBound = 4;
            const int maximalPageCountToCountUpperBound = 8;
            const int minimalPageCountToCountNextPage = 3;

            int pageFrom = 0;
            int pageTo = 0;

            if (CurrentPage < minimalCurrentPageToCountLowerBound)
            {
                pageFrom = 2;
                if (PageCount < maximalPageCountToCountUpperBound)
                {
                    pageTo = PageCount - 1;
                }

                if (PageCount >= maximalPageCountToCountUpperBound)
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
            else if (CurrentPage >= minimalCurrentPageToCountLowerBound)
            {
                pageFrom = CurrentPage - 1;
                if (CurrentPage + 4 > PageCount - 1)
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

            if (CurrentPage >= minimalCurrentPageToCountLowerBound)
            {
                isPreviousPageNeeded = true;
                previousPage = CurrentPage - 2;
            }

            if (PageCount > 7)
            {
                if (PageCount - CurrentPage - 2 > 3)
                {
                    isNextPageNeeded = true;
                    if (CurrentPage > minimalPageCountToCountNextPage)
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
