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
    private readonly IProductRepository memberRepository;
    public ProductService(IProductRepository memberRepository)
    {
      this.memberRepository = memberRepository;
    }

    public Product CreateProducts(string name, string desc, string sku)
    {
      return this.memberRepository.CreateProducts(name, desc, sku);
    }

    public Product DeleteProducts(int id)
    {
      return this.memberRepository.DeleteProducts(id);
    }

    public Product UpdateProducts(int id, string name, string desc, string sku)
    {
      return this.memberRepository.UpdateProducts(id, name, desc, sku);
    }

    List<Product> IProductService.GetProducts()
    {
      return this.memberRepository.GetProducts();
    }
  }
}
