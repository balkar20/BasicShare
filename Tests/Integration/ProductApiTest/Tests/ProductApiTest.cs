using System.Net.Http.Json;
using System.Text;
using Core.Base.Output;
using Mod.Product.Base.ViewModels;
using Mod.Product.Models;
using Mod.ProductTest;
using Moq;

// using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ProductApiTest.Tests
{
    public class ProductApiTest
    {
        private readonly TestProductApiApplication _testProductApiApplication;
        private readonly MockServices _mockServices;
        public readonly HttpClient _client;
        public ProductApiTest()
        {
            _mockServices = new MockServices();
            _testProductApiApplication = new TestProductApiApplication(_mockServices);
 
            _client = _testProductApiApplication.CreateClient();
        }

        [Fact]
        public void TestString()
        {
            var str1 = "Hello";
            var str2 = "Hello";
            
        }
        
        [Fact]
        public async Task  IsGetProductsApiReturnsExpectedResult()
        {
            //Arrange
            var expResult = new List<ProductModel>
            {
                // ("Koko", "Chanell", "Manel")
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Chanell",
                    Description = "Manel"
                }
            };

            var sb = new StringBuilder();
            sb.Append("jhjh");
            
            _mockServices.ProductServiceMock.Setup(m => m.GetAllProducts()).ReturnsAsync(expResult);
            
            //Act
            var response = await _client.GetAsync("api/products");
            var jsonResult =
                await response.Content.ReadFromJsonAsync<OutputViewModelWithData<List<ProductViewModel>>>();

            //Assert
            Assert.Equal(jsonResult?.Data[0].Description, expResult[0].Description);
        }
    }
}