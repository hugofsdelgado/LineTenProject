using LineTen.Application.Interface;
using LineTen.Domain.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LineTen.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : Controller
  {
    private readonly ICustomerService CustomerService;

    public CustomerController(ICustomerService CustomerService)
    {
      this.CustomerService = CustomerService;
    }

    [HttpGet]
    public List<Customer> GetCustomers()
    {
      return this.CustomerService.GetCustomers();
    }

    [HttpPost]
    public ActionResult<Customer> Create(string name, string lastname, string phone, string email)
    {
      try
      {
        return Ok(this.CustomerService.CreateCustomer(name, lastname, phone, email));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message, statusCode: 500);
      }

    }

    [HttpPut]
    public ActionResult<Customer> Edit(int id, string name, string lastname, string phone, string email)
    {
      try
      {
        return Ok(this.CustomerService.UpdateCustomer(id, name, lastname, phone, email));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message, statusCode: 500);
      }
    }

    [HttpDelete]
    public ActionResult<Customer> Delete(int id)
    {
      try
      {
        return Ok(this.CustomerService.DeleteCustomer(id));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message, statusCode: 500);
      }
    }
  }
}
