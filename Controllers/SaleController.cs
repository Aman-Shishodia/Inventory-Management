using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_Management.Models;

namespace Inventory_Management.Controllers
{
    public class SaleController : Controller
    {
        Inventory_ManagementEntities1 db = new Inventory_ManagementEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplaySale()
        {
            return View(db.Sales.OrderByDescending(x => x.Id).ToList());
        }

        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sale s)
        {
            db.Sales.Add(s);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        public ActionResult UpdateSale(int id)
        {
            return View(db.Sales.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult UpdateSale(Sale s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        public ActionResult DetailsSale(int id)
        {
            return View(db.Sales.Where(x=>x.Id==id).FirstOrDefault());
        }

        public ActionResult DeleteSale(int id)
        {
            return View(db.Sales.Where(x=>x.Id==id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult DeleteSale(int id,Sale s) {
            db.Sales.Remove(db.Sales.Where(x=>x.Id==id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
    }
}