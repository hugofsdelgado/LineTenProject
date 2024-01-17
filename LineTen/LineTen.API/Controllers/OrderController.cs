using LineTen.Application.Interface;
using LineTen.Domain.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LineTen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService OrderService;

        public OrderController(IOrderService orderService)
        {
            this.OrderService = orderService;
        }

        [HttpGet]
        public List<Orders> GetOrders()
        {
            return this.OrderService.GetOrders();
        }

        [HttpPost]
        public ActionResult<Orders> Create(OrderAction createOrder)
        {
            try
            {
                return Ok(this.OrderService.CreateOrder(createOrder));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpPut]
        public ActionResult<Orders> Edit(OrderAction updateOrder)
        {
            try
            {
                return Ok(this.OrderService.UpdateOrder(updateOrder));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpDelete]
        public ActionResult<Orders> Delete(int productId, int customerId)
        {
            try
            {
                return Ok(this.OrderService.DeleteOrder(productId, customerId));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
