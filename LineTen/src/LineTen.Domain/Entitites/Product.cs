using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineTen.Domain.Entitites
{
  public class Product
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SKU { get; set; }

    public Product() { }
    public Product(int id,string name, string desc, string sku)
    {
      this.Id = id;
      this.Name = name;
      this.Description = desc;
      this.SKU = sku;

    }
    public Product(string name, string desc, string sku)
    {
      this.Name = name;
      this.Description = desc;
      this.SKU = sku;

    }
  }


}
