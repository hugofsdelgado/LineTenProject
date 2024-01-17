using LineTen.Application.Interface;
using LineTen.Domain.Entitites;
using LineTen.Infrastructure.Context;
using static LineTen.Domain.Entitites.Orders;

namespace LineTen.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        public Orders CreateOrder(int productId, int customerId, OrderStatus status)
        {
            Orders Order;
            try
            {
                using (var contxt = new LineTenContext())
                {
                    var query = from OrderTable in contxt.Orders
                                where OrderTable.ProductId == productId && OrderTable.CustomerId == customerId
                                orderby OrderTable.CustomerId
                                select OrderTable;

                    if (query.Any()) { throw new Exception("Order already made"); }

                    Order = new Orders(productId, customerId, status, DateTime.Now, DateTime.Now);
                    contxt.Orders.Add(Order);
                    contxt.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Order;
        }

        public Orders DeleteOrder(int productId, int customerId)
        {
            Orders Orders;
            using (var contxt = new LineTenContext())
            {
                Orders = contxt.Orders.Where(x => x.ProductId == productId && x.CustomerId == customerId).FirstOrDefault();

                if (Orders != null)
                {
                    contxt.Orders.Remove(Orders);
                    contxt.SaveChanges();
                }
                else
                {
                    throw new Exception("No Order found for the id.");
                }
            }
            return Orders;
        }

        public List<Orders> GetOrders()
        {
            List<Orders> lst = new List<Orders>();
            using (var contxt = new LineTenContext())
            {
                var query = from OrderTable in contxt.Orders
                            orderby OrderTable.CustomerId
                            select OrderTable;

                lst = query.ToList();

            }
            return lst;
        }

        public Orders UpdateOrder(int productId, int customerId, OrderStatus status)
        {
            Orders Orders;
            using (var contxt = new LineTenContext())
            {
                Orders = contxt.Orders.Where(x => x.ProductId == productId && x.CustomerId == customerId).FirstOrDefault();

                if (Orders != null)
                {
                    Orders.Status = status;
                    Orders.UpdatedDate = DateTime.Now;
                    contxt.SaveChanges();
                }
                else
                {
                    throw new Exception("No Order found for the pair ids.");
                }
            }
            return Orders;
        }
    }
}
