using ExpectedObjects;
using LineTen.Domain.Entitites;
using System.Xml.Linq;

namespace LineTen.Domain.Test.Products
{
  public class ProductsTest
  {
    [Fact(DisplayName = "FirstTest")]
    public void FirstTest()
    {
      Entitites.Product product1 = new Entitites.Product(1, "Name1", "Desc1", "123456");
      Entitites.Product product2 = new Entitites.Product(2, "Name1", "Desc1", "123456");


      Assert.Equal(product1.Name, product2.Name);
      Assert.Equal(product1.Description, product2.Description);
      Assert.Equal(product1.SKU, product2.SKU);

      product1.Id = product2.Id;

    }

    [Theory]
    [InlineData(new object[] { 1, "Name1", "Desc1", "123456" })]
    [InlineData(new object[] { 2, "Name2", "Desc2", "123456" })]
    public void SecondtTest(int id, string name, string desc, string sku)
    {

      var expectedProduct = new Entitites.Product(2, "Name2", "Desc2", "123456");
      var actualProduct = new Entitites.Product(id, name, desc, sku);

      actualProduct.ToExpectedObject().ShouldMatch(expectedProduct);


    }
  }
}