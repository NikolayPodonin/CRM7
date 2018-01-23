using CRM7.DataModel.OnlineStore;
using CRM7.DataModel.Product;
using CRM7.Service;
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
            Catalogue catalogue = new Catalogue();
            var cat = catalogue.GetAllCatalogs().First();
            List<ProductCategory> categories = catalogue.GetProductCategoriesFromCatalog(cat.Id);
            return View(categories);
        }
        
        public ActionResult Products(ProductCategory category)
        {
            Catalogue catalogue = new Catalogue();
            var cat = catalogue.GetAllCatalogs().First();
            List<IProductModel> categories = cat.GetAllModels().FindAll(i => i.Category.Id == category.Id);
            return View(categories);
        }

        public ActionResult Bikes()
        {
            Catalogue catalogue = new Catalogue();
            var cat = catalogue.GetAllCatalogs().First();
            List<ProductCategory> categories = catalogue.GetProductCategoriesFromCatalog(cat.Id);
            return View(categories);
        }

        public ActionResult BooksSportsHobbies()
        {
            return View();
        }
        

    }
}