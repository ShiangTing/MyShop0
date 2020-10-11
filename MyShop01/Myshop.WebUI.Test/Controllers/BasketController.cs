using Myshop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myshop.Core.Models;
using Myshop.Service;

namespace Myshop.WebUI.Test.Controllers
{
    public class BasketController : Controller

    {
        IBasketService basketService;
        IOrderService orderService;

        public BasketController(IBasketService BasketService, IOrderService OrderService)
        {
            this.basketService = BasketService;
            this.orderService = OrderService;
         
        }
        // GET: Basket2
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }

        public ActionResult Checkout()
        {
            return View();


        }

        [HttpPost]
        [Authorize]
        public ActionResult Checkout(Order order)
        {

            var basketItems = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";
            order.Email = User.Identity.Name;

            //process payment

            order.OrderStatus = "Payment Processed";
            orderService.CreateOrder(order, basketItems);
            basketService.ClearBasket(this.HttpContext);

            return RedirectToAction("Thankyou", new { OrderId = order.Id });
        }

        public ActionResult ThankYou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
        //IBasketService basketSeervice;
        //IOrderService orderService;

        //public BasketController(IBasketService BasketService, IOrderService orderService)
        //{
        //    this.basketSeervice = BasketService;
        //    this.orderService = orderService;
        //}


        //// GET: Basket
        //public ActionResult Index()
        //{
        //    var model = basketSeervice.GetBasketItems(this.HttpContext);
        //    return View(model);
        //}

        //public ActionResult AddToBasket(string Id)
        //{
        //    basketSeervice.AddToBasket(this.HttpContext, Id);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult RemoveFromBasket(string Id)
        //{
        //    basketSeervice.RemoveFromBasket(this.HttpContext, Id);
        //    return RedirectToAction("Index");
        //}

        //public PartialViewResult BasketSummary()
        //{
        //    var basketSummary = basketSeervice.GetBasketSummary(this.HttpContext);
        //    return PartialView(basketSummary);
        //}

        //public ActionResult Checkout()
        //{
        //    return View();


        //}

        //[HttpPost]
        //public ActionResult CheckOut(Order order)
        //{
        //    var basketItems = basketSeervice.GetBasketItems(this.HttpContext);
        //    order.OrderStatus = "Order Created";
        //    order.Email = User.Identity.Name;

        //    //process payment

        //    order.OrderStatus = "Payment Processed";
        //    orderService.CreateOrder(order, basketItems);
        //    basketSeervice.ClearBasket(this.HttpContext);
        //    return RedirectToAction("Thankyou", new { OrderId = order.Id });
        //}
        //public ActionResult ThankYou(string OrderId)
        //{
        //    ViewBag.OrderId = OrderId;
        //    return View();
        //}
    }
}