using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccessLayer;
using WebApplication1.Repositories;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    public class StockItemsController : Controller
    {
        private StockItemsRepositories repo = new StockItemsRepositories();
        private StoreContext db = new StoreContext();
        private static string SearchSave;

        public StockItemsController()
        {
            SearchSave = "";
        }

        // GET: StockItems
        public ActionResult Index(string Search = "" , string sort = "Name")
        {
            if (Search != "" )
            {
                SearchSave = Search;
            }
            return View(repo.GetAllItems(SearchSave, sort));
        }

        public ActionResult Details(int id = -1)
        {
            var returnTemp = repo.GetItemByID(id);
            return View(returnTemp);
        }

        public ActionResult Edit(int id = -1)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = repo.GetItemByID(id);
            if(stockItem == null)
            {
                return HttpNotFound();
            }
            return View(stockItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,Name,Price,Shelf,Description")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                repo.ChangeItemInRepositorie(stockItem);
                return RedirectToAction("Index");
            }
            return View(stockItem);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,Name,Price,Shelf,Description")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {
                repo.AddToRepositorie(stockItem);
                return RedirectToAction("Index");
            }

            return View(stockItem);
        }

        public ActionResult Delete(int id=-1)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = repo.GetItemByID(id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }
            return View(stockItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockItem stockItem = repo.GetItemByID(id);
            repo.RemoveFromRepositorie(stockItem);
            return RedirectToAction("Index");
        }

       
    }
}