using ExpectedObjects;
using LineTen.Domain.Entitites;
using System.Diagnostics;
using System.Net.Http;
using System.Xml.Linq;

namespace LineTen.Domain.Test.Products
{
  public class ProductsTest
  {

    public readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:44383/") };

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

    [Theory]
    [InlineData(9999)]
    [InlineData(0)]
    public async Task GivenAWrongID_WhenCallingEdit_ThenTheAPIReturnsBadRequest(int id)
    {
      var expectedStatusCode = System.Net.HttpStatusCode.InternalServerError;
      var response = await _httpClient.DeleteAsync($"/DeleteProduct?id={id}");
      Assert.True(expectedStatusCode == response.StatusCode);
    }


    [Fact]
    public async Task WhenCallingGetAllProducts_ThenTheAPIReturnsOk()
    {
      var expectedStatusCode = System.Net.HttpStatusCode.OK;
      var request = new HttpRequestMessage(HttpMethod.Get, $"/GetProducts");
      var response = await _httpClient.SendAsync(request);
      Assert.True(expectedStatusCode == response.StatusCode);
    }
  }
}