using LineTen.Domain.Entitites;
using static LineTen.Domain.Entitites.Orders;

namespace LineTen.Application.Interface
{
  public interface IOrderRepository
  {
    List<Orders> GetOrders();
    Orders CreateOrder(int productId, int customerId, OrderStatus status);
    Orders UpdateOrder(int productId, int customerId, OrderStatus status);
    Orders DeleteOrder(int productId, int customerId);

  }
}
