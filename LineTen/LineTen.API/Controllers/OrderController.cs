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
    private readonly ICustomerService CustomerService;
    private readonly IProductService ProductService;

    public OrderController(IOrderService orderService, ICustomerService customerService, IProductService productService)
    {
      this.OrderService = orderService;
      this.CustomerService = customerService;
      this.ProductService = productService;
    }

    [HttpGet]
    public List<Orders> GetOrders()
    {
      return this.OrderService.GetOrders();
    }

    [HttpPost]
    public ActionResult<Orders> Create(string product, string customer)
    {
      try
      {
        int productId = ProductService.GetProducts().FirstOrDefault(x => x.Name == product).Id;
        int customerId = CustomerService.GetCustomers().FirstOrDefault(x => x.FirstName == customer).Id;
        return Ok(this.OrderService.CreateOrder(productId, customerId, Orders.OrderStatus.ordered));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message, statusCode: 500);
      }

    }

    [HttpPut]
    public ActionResult<Orders> Edit(string product, string customer, int status)
    {
      try
      {
        int productId = ProductService.GetProducts().FirstOrDefault(x => x.Name == product).Id;
        int customerId = CustomerService.GetCustomers().FirstOrDefault(x => x.FirstName == customer).Id;
        return Ok(this.OrderService.CreateOrder(productId, customerId, (Orders.OrderStatus)status));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message, statusCode: 500);
      }
    }

    [HttpDelete]
    public ActionResult<Orders> Delete(string product, string customer)
    {
      try
      {
        int productId = ProductService.GetProducts().FirstOrDefault(x => x.Name == product).Id;
        int customerId = CustomerService.GetCustomers().FirstOrDefault(x => x.FirstName == customer).Id;
        return Ok(this.OrderService.DeleteOrder(productId, customerId));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message, statusCode: 500);
      }
    }
  }
}
