using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Site.Models;

namespace Site.Controllers
{
    public class CatalogController : Controller
    {
        private ApplicationContext db;

        public CatalogController(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<IActionResult> Catalog()
        {
            return View(await db.Products.ToListAsync());
        }

        public IActionResult Cart()
        {
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))//проверка на наличие корзины
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));
            return View(cart);
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}
