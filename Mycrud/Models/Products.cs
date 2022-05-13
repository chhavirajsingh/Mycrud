using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mycrud.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public String Description { get; set; }
        public Category Category { get; set; }
    }
}