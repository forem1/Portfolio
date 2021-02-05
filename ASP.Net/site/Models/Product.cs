using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string PictureMain { get; set; }
        public string PictureTwo { get; set; }
        public string PictureThree { get; set; }
        public string PictureFour { get; set; }
        public string PictureFive { get; set; }
    }
}
