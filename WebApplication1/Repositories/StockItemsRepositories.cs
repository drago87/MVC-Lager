using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class StockItemsRepositories
    {
        private StoreContext context;
        public StockItemsRepositories()
        {
            context = new StoreContext();
        }

        public IEnumerable<StockItem> GetAllItems()
        {
            return context.Items;
        }

        public StockItem GetItemByID(int id)
        {
            return context.Items.FirstOrDefault(b => b.ItemID == id);
        }

        public void ChangeItemInRepositorie(StockItem stockItem)
        {
            context.Entry(stockItem).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void AddToRepositorie(StockItem stockItem)
        {
            context.Items.Add(stockItem);
            context.SaveChanges();
        }

        public void RemoveFromRepositorie(StockItem stockItem)
        {
            context.Items.Remove(stockItem);
            context.SaveChanges();
        }
    }
}