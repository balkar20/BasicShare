using System.Net.Http.Json;
using Core.Base.Output;
using Mod.Product.Base.ViewModels;
using ModProduct.Models;
using Moq;

// using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ProductApiTest.Tests
{
    public class ProductApiTest
    {
        private readonly TestMoqPOCApplication _testMoqPOCApplication;
        private readonly MockServices _mockServices;
        public readonly HttpClient _client;
        public ProductApiTest()
        {
            _mockServices = new MockServices();
            _testMoqPOCApplication = new TestMoqPOCApplication(_mockServices);
 
            _client = _testMoqPOCApplication.CreateClient();
        }
        [Fact]
        public async Task  IsGetProductsApiReturnsExpectedResult()
        {
            //Arrange
            var expResult = new List<ProductModel>
            {
                new ProductModel("Koko", "Chanell", "Manel")
            };
            var expMapperResult = new ProductViewModel("NewId", "NewBAlias", "NewPAlias");
            _mockServices.ProductServiceMock.Setup(m => m.GetAllProducts()).ReturnsAsync(expResult);
            
            //Act
            var response = await _client.GetAsync("api/products");
            var jsonResult =
                await response.Content.ReadFromJsonAsync<OutputViewModelWithData<List<ProductViewModel>>>();

            //Assert
            Assert.Equal(jsonResult.Data[0].ProductAlias, expResult[0].ProductAlias);
        }
    }
}