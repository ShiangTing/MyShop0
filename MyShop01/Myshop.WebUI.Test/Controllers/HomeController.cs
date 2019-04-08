using Myshop.Core.Contracts;
using Myshop.Core.Models;
using Myshop.Core.ViewModels;
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
        public ActionResult Index(string Categoery =null)

        { // 增加product list
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();
            if (Categoery == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Categoery).ToList();
            }
            ProductListViewModels models = new ProductListViewModels();
            models.Products = products;
            models.productCategories = categories;

            return View(models);
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