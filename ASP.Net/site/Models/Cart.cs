using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Cart
    {
        public List<Product> CartLines { get; set; }

        public Cart()
        {
            CartLines = new List<Product>();
        }

        public int FinalPrice
        {
            get
            {
                int sum = 0;
                foreach(Product product in CartLines)
                {
                    sum += product.Price;
                }
                return sum;
            }
        }
    }
}
