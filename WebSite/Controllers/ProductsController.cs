using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebSite.DBModels;
using WebSite.ShowModels;
using WebSite.DBProvider;

namespace WebSite.Controllers
{
    public class ProductsController : Controller
    {
        IDbReader dbReader;

        public ProductsController(IDbReader dbProvider)
        {
            this.dbReader = dbProvider;
        }

        // GET: GoodsController
        public ActionResult Product()
        {
            ProductsShowModel productsShowModel = new ProductsShowModel(dbReader.GetProducts
                (x => x.IsFavorite == true));

            return View(productsShowModel);
        }

        // GET: GoodsController/5
        public ActionResult Products(int page)
        {
            ProductsShowModel productShowModel = new ProductsShowModel(dbReader.GetAllProducts(), page - 1);

            return View(productShowModel);
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: GoodsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
