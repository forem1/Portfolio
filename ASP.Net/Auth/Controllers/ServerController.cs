using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace WebAuthorize.Controllers
{
    [Serializable]
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class ServerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logg()
        {
            return View();
        }

        public ActionResult Err()
        {
            return View();
        }

        public ActionResult Succes()
        {
            return View();
        }
        public ActionResult Post()
        {
            List<User> users = new List<User>();
            try
            {
                using (FileStream file = new FileStream("C:/Information/users.xml", FileMode.OpenOrCreate))
                    users = (List<User>)new XmlSerializer(typeof(List<User>)).Deserialize(file);
            }
            catch { }
            users.Add(new User
            {
                Login = Request.Form["Login"],
                Password = Request.Form["Password"],
                Email = Request.Form["Email"],
            });
            using (FileStream file = new FileStream(@"C:/Information/users.xml", FileMode.Create))
            new XmlSerializer(typeof(List<User>)).Serialize(file, users);
            return View("~/Views/Server/Logg.cshtml");
        }

        public ActionResult Get()
        {
            List<User> users = new List<User>();
            try
            {
                using (FileStream file = new FileStream("C:/Information/users.xml", FileMode.OpenOrCreate))
                    users = (List<User>)new XmlSerializer(typeof(List<User>)).Deserialize(file);
            }
            catch { }
            if (users.Count(x => x.Login == Request.Params["login"] && x.Password == Request.Params["pass"]) > 0)
            {
                User user = users.First(x => x.Login == Request.Params["login"] && x.Password == Request.Params["pass"]);
                ViewBag.login = user.Login;
                ViewBag.password = user.Password;
                ViewBag.email = user.Email;
                return View("Succes");
            }
            else
            {
                return View("Error");
            }
        }

      
    }
}