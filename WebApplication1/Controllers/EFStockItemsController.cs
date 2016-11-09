using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccessLayer;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EFStockItemsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: EFStockItems
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: EFStockItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = db.Items.Find(id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }
            return View(stockItem);
        }

        // GET: EFStockItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EFStockItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,Name,Price,Shelf,Description")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(stockItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockItem);
        }

        // GET: EFStockItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = db.Items.Find(id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }
            return View(stockItem);
        }

        // POST: EFStockItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,Name,Price,Shelf,Description")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockItem);
        }

        // GET: EFStockItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = db.Items.Find(id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }
            return View(stockItem);
        }

        // POST: EFStockItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockItem stockItem = db.Items.Find(id);
            db.Items.Remove(stockItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
