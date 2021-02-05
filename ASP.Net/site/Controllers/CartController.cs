using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class CartController : Controller
    {
       private Models.ApplicationContext db;
        public CartController(Models.ApplicationContext context)
        {
            db = context;
        }

        public IActionResult AddToCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]); //Получаем ид из строки
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))//проверка на наличие корзины
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart")); //десериализация корзины
            cart.CartLines.Add(db.Products.Find(ID));//добавляем в корзину товар по ид
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));//Сохраняет новую корзину в сессию
            return Redirect("/"); //Возвращаем на главную
        }

        public IActionResult RemoveFromCart()
        {
            int number = Convert.ToInt32(Request.Query["Number"]);
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))//проверка на наличие корзины
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart")); //десериализация корзины
            cart.CartLines.RemoveAt(number);//Удаляем в корзину товар по ид
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));//Сохраняет новую корзину в сессию
            return Redirect("/Cart"); //Возвращаем на главную
        }
    }
}
