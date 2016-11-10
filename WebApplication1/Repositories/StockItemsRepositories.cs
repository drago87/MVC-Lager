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

        public IEnumerable<StockItem> GetAllItems(string Search, string sort)
        {
            var temp2 = from i in context.Items
                        where i.Name.Contains(Search)
                        select i;
            var temp3 = temp2.AsEnumerable().OrderBy(o => o.GetType().GetProperty(sort).GetValue(o, null));
            //var temp = context.Items.AsEnumerable().OrderBy(o => o.GetType().GetProperty(sort).GetValue(o, null));//.Any(item => item.Name == Search);
            //var temp2 = 
            //var temp = from i in context.Items
            //           select i;
            //var temp2 = from i in temp
              //          select   
            return temp3;
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

        public IEnumerable<StockItem> SortRepositorieByName()
        {
            return context.Items.OrderBy(s => s.Name);
            
        }

        public IEnumerable<StockItem> SortRepositorieByPrice()
        {
            return context.Items.OrderBy(s => s.Price);
            
        }
    }
}