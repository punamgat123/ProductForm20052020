using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsGSTApplicable { get; set; }        
        public DateTime Purchase_Date { get; set; }
        public DateTime ExpiryDate { get; set; }
        // public string Color { get; set; }
    }
}