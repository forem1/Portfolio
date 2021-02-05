using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Site.Models;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        public IActionResult Contacts()
        {
            return View();
        }
    }
}
