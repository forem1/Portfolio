using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Product
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public bool IsTangible { get; set; }
    }
}