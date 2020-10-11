using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Myshop.Core.Models;
using Myshop.Core.ViewModels;

namespace Myshop.Core.Contracts
{
    public interface IOrderService
    {
        //拿到訂單 和Basketitem的List
        void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems);
    }
}
