using Mycrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mycrud.Models.ViewModel;

namespace Mycrud.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            var products = dbContext.Products.ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            return View ();
        }
        [HttpPost]
        public ActionResult Create(Products product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = dbContext.Products.
                SingleOrDefault(e=> e.Id==id);
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int ?id)
        {
            var Product= dbContext.Products.SingleOrDefault
                (e => e.Id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Products product)
        {
            dbContext.Entry(product).State=System.Data.Entity.
                EntityState.Modified;
            dbContext.SaveChanges();
            return View();
        }

        public ActionResult AllDetails()
        {
            var products = (from a in dbContext.Products join b in dbContext.Categories on a.Id equals b.Id

              select new allclass
              {
                 Id=a.Id,
                 Name=a.Name,
                 Quantity=a.Quantity,
                 Price=a.Price,
                 Category=b.Name
              });
            return View(products);
        }
    }
}