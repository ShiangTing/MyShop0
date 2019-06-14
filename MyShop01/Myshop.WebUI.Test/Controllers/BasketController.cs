using Myshop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myshop.Service;

namespace Myshop.WebUI.Test.Controllers
{
    public class BasketController : Controller

    {
        IBasketService basketSeervice;
        public BasketController (IBasketService BasketService)
        {
            this.basketSeervice = BasketService;
        }


        // GET: Basket
        public ActionResult Index()
        {
            var model = basketSeervice.GetBasketItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(string Id)
        {
            basketSeervice.AddToBasket(this.HttpContext, Id);
            System.Diagnostics.Debug.WriteLine("Hello------------------------");
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromBasket(string Id)
        {
            basketSeervice.RemoveFromBasket(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketSeervice.GetBasketSummary(this.HttpContext);
            return PartialView(basketSummary);
        }

    }
}