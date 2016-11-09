using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DataAccessLayer
{
    public class StoreContext : DbContext
    {
        public DbSet<StockItem> Items { get; set; }

        public StoreContext() : base("DefaultConnection")
        {

        }
    }
}