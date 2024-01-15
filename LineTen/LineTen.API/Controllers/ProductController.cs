using LineTen.Application.Interface;
using LineTen.Domain.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace LineTen.API.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductService productService;

    public ProductController(IProductService productService)
    {
      this.productService = productService;
    }

    [HttpGet("GetProducts")]
    public List<Product> GetProducts()
    {
      return this.productService.GetProducts();
    }

    [HttpPost("CreateProduct")]
    public ActionResult<Product> Create(string name, string desc, string sku)
    {
      try
      {
        return Ok(this.productService.CreateProducts(name, desc, sku));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message);
      }

    }

    [HttpGet("UpdateProduct")]
    public ActionResult<Product> Edit(int id, string name, string desc, string sku)
    {
      try
      {
        return Ok(this.productService.UpdateProducts(id, name, desc, sku));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message);
      }
    }

    [HttpDelete("DeleteProduct")]
    public ActionResult<Product> Delete(int id)
    {
      try
      {
        return Ok(this.productService.DeleteProducts(id));
      }
      catch (Exception ex)
      {
        return Problem(ex.Message);
      }
    }

  }
}
