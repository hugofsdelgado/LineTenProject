using LineTen.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineTen.Application.Interface
{
  public interface IProductRepository
  {
    List<Domain.Entitites.Product> GetProducts();
    Product CreateProducts(string name, string desc, string sku);
    Product UpdateProducts(int id, string name, string desc, string sku);
    Product DeleteProducts(int id);

  }
}
