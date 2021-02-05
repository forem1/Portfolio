using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Models.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Product p = new Product()
            {
                Id = 1,
                Name = "",
                IsTangible = false
            };
            return View(p);
        }

    }
}