using Myshop.Core.Contracts;
using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myshop.WebUI.Test.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context; //Load product from the database
        IRepository<ProductCategory> productCategories;//Load productCategories from the database
        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        { // create a new instance(initialize)
          // Concreat Implementation of IRepository
            context = productContext;
            productCategories = productCategoryContext;
        }
        public ActionResult Index()
        { // 增加product list
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if (Id == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}