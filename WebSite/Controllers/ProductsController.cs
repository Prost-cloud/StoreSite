using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebSite.DBModels;

namespace WebSite.Controllers
{
    public class ProductsController : Controller
    {
        // GET: GoodsController
        public ActionResult Products()
        {
            List<Products> products = new List<Products>();

            products.Add(new Products { guid = Guid.NewGuid(), Name = "Cheese", Description = "That flavour piece of cheese make you happy for whole day!"});
            products.Add(new Products { guid = Guid.NewGuid(), Name = "Sausage", Description = "That delicious sausage maden by franch chef called Chicken destroyer"});
            products.Add(new Products { guid = Guid.NewGuid(), Name = "Pizza", Description = "Master piese pizza by famous italian dude Giovanni Giorgio"});
            products.Add(new Products { guid = Guid.NewGuid(), Name = "Coca-Cola", Description = "We are not fat shamers"});
            products.Add(new Products { guid = Guid.NewGuid(), Name = "Wine", Description = "Tasty wine for man that known taste of life"});
            products.Add(new Products { guid = Guid.NewGuid(), Name = "Vodka", Description = "Suka Blyat"});
            products.Add(new Products { guid = Guid.NewGuid(), Name = "Beer", Description = "Gomer's special" });

            return View(products);
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

        // GET: GoodsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoodsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GoodsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GoodsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GoodsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GoodsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
