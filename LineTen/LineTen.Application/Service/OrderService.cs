using LineTen.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static LineTen.Domain.Entitites.Orders;

namespace LineTen.Application.Interface
{
  public class OrderService : IOrderService
  {
    private readonly IOrderRepository OrderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
      this.OrderRepository = orderRepository;
    }

    public Orders CreateOrder(int productId, int customerId, OrderStatus status)
    {
      return this.OrderRepository.CreateOrder(productId, customerId, status);
    }

    public Orders DeleteOrder(int productId, int customerId)
    {
      return this.OrderRepository.DeleteOrder(productId, customerId);
    }

    public List<Orders> GetOrders()
    {
      return this.OrderRepository.GetOrders();
    }

    public Orders UpdateOrder(int productId, int customerId, OrderStatus status)
    {
      return this.OrderRepository.UpdateOrder(productId, customerId, status);
    }
  }
}
