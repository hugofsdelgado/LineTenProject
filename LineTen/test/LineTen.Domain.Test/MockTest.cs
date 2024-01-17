using LineTen.Application.Interface;
using LineTen.Domain.Entitites;
using Moq;
using Newtonsoft.Json;

namespace LineTen.Domain.Test
{
    public class MockTest
    {

        public readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:44383/") };
        private readonly Mock<IProductRepository> _mockTodoRepository = new Mock<IProductRepository>();
        private readonly Mock<IOrderRepository> _mockOrderRepository = new Mock<IOrderRepository>();
        public Mock<IProductRepository> MockTodoRepository => _mockTodoRepository;
        public Mock<IOrderRepository> MockOrderRepository => _mockOrderRepository;

        [Fact(DisplayName = "GetAllProducts_ReturnsEmptyList")]
        public async void GetAllProducts_ReturnsListOfProducts()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Product");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            List<Product> productsLst = JsonConvert.DeserializeObject<List<Product>>(await response.Content.ReadAsStringAsync());
            Assert.True(productsLst.GetType()==typeof(List<Product>));
        }


        [Theory]
        [InlineData(new object[] { "Hugo", "Desc1", "123456" })]
        [InlineData(new object[] { "Manuel", "Desc2", "123456" })]
        public async Task AddProduct_ReturnsCreatedTodoWithCorrectValues(string name, string desc, string sku)
        {
            // Arrange
            Product product = new Product { Name = name, Description = desc, SKU = sku };
            _mockTodoRepository.Setup(repo => repo.CreateProducts(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(product);

            // Act
            var request = new HttpRequestMessage(HttpMethod.Post, $"/api/Product?name={product.Name}&desc={product.Description}&sku={product.SKU}");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // Assert
            var createdTodo = JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync());
            Assert.Equal(product.Name, createdTodo.Name);
            Assert.Equal(product.Description, createdTodo.Description);
            Assert.Equal(product.SKU, createdTodo.SKU);
        }

        [Theory]
        [InlineData(9999)]
        [InlineData(0)]
        public async Task GivenAWrongID_WhenCallingDelete_ThenTheAPIReturnsBadRequest(int id)
        {
            var expectedStatusCode = System.Net.HttpStatusCode.InternalServerError;
            var response = await _httpClient.DeleteAsync($"/api/Product?id={id}");
            Assert.True(expectedStatusCode == response.StatusCode);
        }


        [Fact]
        public async Task WhenCallingGetAllProducts_ThenTheAPIReturnsOk()
        {
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Product");
            var response = await _httpClient.SendAsync(request);
            Assert.True(expectedStatusCode == response.StatusCode);
        }
    }
}