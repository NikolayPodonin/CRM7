using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<ProductCategory> categories = new List<ProductCategory>()
            {
                new ProductCategory() { UserId = Guid.NewGuid(), Name = "Cars", IconCssProperty = "fa-car" },
                new ProductCategory() { UserId = Guid.NewGuid(), Name = "Bikes", IconCssProperty = "FlaticonCars-005-wheel" }
            };
            return View(categories);
        }

        public ActionResult Typography()
        {
            return View();
        }

        public ActionResult AllClassifieds()
        {
            return View();
        }

        public ActionResult Bikes()
        {
            return View();
        }

        public ActionResult BooksSportsHobbies()
        {
            return View();
        }

        public ActionResult Cars()
        {
            return View();
        }


    }
}