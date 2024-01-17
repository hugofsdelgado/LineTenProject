using LineTen.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LineTen.Application.Interface
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository productRepository;
    public ProductService(IProductRepository productRepository)
    {
      this.productRepository = productRepository;
    }

    public Product CreateProducts(string name, string desc, string sku)
    {
      return this.productRepository.CreateProducts(name, desc, sku);
    }

    public Product DeleteProducts(int id)
    {
      return this.productRepository.DeleteProducts(id);
    }

    public List<Product> GetProducts()
    {
      return this.productRepository.GetProducts();
    }

    public Product UpdateProducts(int id, string name, string desc, string sku)
    {
      return this.productRepository.UpdateProducts(id, name, desc, sku);
    }
  }
}
