using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_Management.Models;

namespace Inventory_Management.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_ManagementEntities1 db = new Inventory_ManagementEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayPurchase()
        {
            return View(db.Purchases.OrderByDescending(x=>x.Id).ToList());
        }

        public ActionResult PurchaseProduct()
        {
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult PurchaseProduct(Purchase p)
        {
            db.Purchases.Add(p);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        public ActionResult UpdatePurchase(int id)
        {
            return View(db.Purchases.Where(x=>x.Id==id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult UpdatePurchase(Purchase p)
        {
            db.Entry(p).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        public ActionResult DetailsPurchase(int id)
        {
            return View(db.Purchases.Where(x=>x.Id==id).FirstOrDefault());
        }

        public ActionResult DeletePurchase(int id)
        {
            return View(db.Purchases.Where(x=>x.Id==id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult DeletePurchase(int id, Purchase p)
        {
            db.Purchases.Remove(db.Purchases.Where(x=>x.Id==id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
        
    }
}