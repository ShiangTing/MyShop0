using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Myshop.Core.Contracts;
using Myshop.Core.Models;
using Myshop.Core.ViewModels;

namespace Myshop.Service
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> orderContext;

        public OrderService(IRepository<Order> orderContext)
        {
            this.orderContext = orderContext;
        }
        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Image = item.Image,
                    Quanity = item.Quanity
                });

               
            }
            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }
    }
}
