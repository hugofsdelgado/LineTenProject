using LineTen.Application.Interface;
using LineTen.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineTen.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        public static List<Products> lstProducts = new List<Products>()
        {
            new Products(1,"Name1", "Desc1", "1234567891" ),
            new Products(2,"Name2", "Desc2", "1234567892" ),
            new Products(3,"Name3", "Desc3", "1234567893" ),
            new Products(4,"Name4", "Desc4", "1234567894" )
        };

        public List<Products> GetProducts()
        {
            return lstProducts;
        }
    }
}
