using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_Management.Models;

namespace Inventory_Management.Controllers
{
    public class ProductController : Controller
    {
        Inventory_ManagementEntities1 db = new Inventory_ManagementEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayProduct() { return View(db.Products.OrderByDescending(x=>x.Id).ToList()); }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        public ActionResult UpdateProduct(int id) { return View(db.Products.Where(x=>x.Id==id).FirstOrDefault()); }

        [HttpPost]
        public ActionResult UpdateProduct(Product p)
        {
            if (ModelState.IsValid)
            {

                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DisplayProduct");
            }
            return View();
        }

        public ActionResult DetailsProduct(int id) {
            var row = db.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(row);
        }

        public ActionResult DeleteProduct(int id) {
            return View(db.Products.Where(x => x.Id == id).FirstOrDefault());
                }

        [HttpPost]
        public ActionResult DeleteProduct(int id, Product p)
        {
            if (ModelState.IsValid)
            {

                db.Products.Remove(db.Products.Where(x => x.Id == id).FirstOrDefault());
                db.SaveChanges();
                return RedirectToAction("DisplayProduct");
            }
            return View();
        }
    }
}