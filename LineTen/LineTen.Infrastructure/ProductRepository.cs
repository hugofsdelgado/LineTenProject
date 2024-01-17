using LineTen.Application.Interface;
using LineTen.Domain.Entitites;
using LineTen.Infrastructure.Context;

namespace LineTen.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        public static List<Product> lstProducts = new List<Product>()
        {
            new Product(1,"Name1", "Desc1", "1234567891" ),
            new Product(2,"Name1", "Desc1", "1234567891" )
        };

        public Product CreateProducts(string name, string desc, string sku)
        {
            Product product;
            try
            {
                using (var contxt = new LineTenContext())
                {
                    product = new Product(name, desc, sku);

                    contxt.Products.Add(product);
                    contxt.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public Product DeleteProducts(int id)
        {
            Product products;
            using (var contxt = new LineTenContext())
            {
                products = contxt.Products.Where(x => x.Id == id).FirstOrDefault();

                if (products != null)
                {
                    contxt.Products.Remove(products);
                    contxt.SaveChanges();
                }
                else
                {
                    throw new Exception("No product found for the id.");
                }
            }
            return products;
        }

        public Product GetProductByName(string name)
        {

            Product product = new Product();

            using (var contxt = new LineTenContext())
            {
                var query = from productTable in contxt.Products
                            where productTable.Name == name
                            orderby productTable.Id
                            select productTable;

                product = query.FirstOrDefault();
            }

            if (product == null)
            {
                throw new Exception($"Product not found by the name {name}.");
            }

            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> lst = new List<Product>();
            using (var contxt = new LineTenContext())
            {
                var query = from productTable in contxt.Products
                            orderby productTable.Id
                            select productTable;

                lst = query.ToList();

            }
            return lst;
        }

        public Product UpdateProducts(int id, string? name, string? desc, string? sku)
        {
            Product products;
            using (var contxt = new LineTenContext())
            {
                products = contxt.Products.Where(x => x.Id == id).FirstOrDefault();

                if (products != null)
                {
                    products.Name = !string.IsNullOrEmpty(name) && products.Name != name ? name : products.Name;
                    products.Description = !string.IsNullOrEmpty(desc) && products.Description != desc ? desc : products.Description;
                    products.SKU = !string.IsNullOrEmpty(sku) && products.SKU != sku ? sku : products.SKU;
                    contxt.SaveChanges();
                }
                else
                {
                    throw new Exception("No product found for the id.");
                }
            }
            return products;
        }
    }
}
