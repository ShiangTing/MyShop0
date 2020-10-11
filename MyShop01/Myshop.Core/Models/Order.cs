using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.Models
{
    public  class Order :BaseEntity
    {
        public Order()
        {//初始化
            this.OrderItems = new List<OrderItem>();
        }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string OrderStatus { get; set; }

        //link two together, when we load Order we will get the order item
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
