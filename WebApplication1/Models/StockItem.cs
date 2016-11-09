using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class StockItem
    {
        [Key]
        public int ItemID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Shelf { get; set; }
        public string Description { get; set; }
    }
}