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
        private readonly ICustomerRepository CustomerRepository;
        private readonly IProductRepository ProductRepository;
        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            OrderRepository = orderRepository;
            CustomerRepository = customerRepository;
            ProductRepository = productRepository;
        }

        public Orders CreateOrder(OrderAction createOrder)
        {
            try
            {
                int customerId = CustomerRepository.GetCustomerByName(createOrder.CustomerName).Id;
                int productId = ProductRepository.GetProductByName(createOrder.ProductName).Id;
                return OrderRepository.CreateOrder(productId, customerId, OrderStatus.ordered);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Orders DeleteOrder(int productId, int customerId)
        {
            return OrderRepository.DeleteOrder(productId, customerId);
        }

        public List<Orders> GetOrders()
        {
            return OrderRepository.GetOrders();
        }

        public Orders UpdateOrder(OrderAction updateOrder)
        {
            int customerId = CustomerRepository.GetCustomerByName(updateOrder.CustomerName).Id;
            int productId = ProductRepository.GetProductByName(updateOrder.ProductName).Id;
            return OrderRepository.UpdateOrder(productId, customerId, updateOrder.Status);
        }
    }
}
