using LineTen.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LineTen.Domain.Entitites.Orders;

namespace LineTen.Application.Interface
{
  public interface IOrderService
  {
    List<Orders> GetOrders();
    Orders CreateOrder(OrderAction createOrder);
    Orders UpdateOrder(OrderAction updateOrder);
    Orders DeleteOrder(int productId, int customerId);

  }
}
