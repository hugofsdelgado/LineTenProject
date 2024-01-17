using LineTen.Application.Interface;
using LineTen.Domain.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace LineTen.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : Controller
  {
    private readonly IProductService productService;

    public ProductController(IProductService productService)
    {
      this.productService = productService;
    }

    [HttpGet]
    public List<Product> GetProducts()
    {
      return this.productService.GetProducts();
    }

    [HttpPost]
    public ActionResult<Product> Create(string name, string desc, string sku)
    {
      try
      {
        return Ok(this.productService.CreateProducts(name, desc, sku));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message, statusCode: 500);
      }

    }

    [HttpPut]
    public ActionResult<Product> Edit(int id, string? name, string? desc, string? sku)
    {
      try
      {
        return Ok(this.productService.UpdateProducts(id, name, desc, sku));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message, statusCode: 500);
      }
    }

    [HttpDelete]
    public ActionResult<Product> Delete(int id)
    {
      try
      {
        return Ok(this.productService.DeleteProducts(id));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message, statusCode:500);
      }
    }

  }
}
