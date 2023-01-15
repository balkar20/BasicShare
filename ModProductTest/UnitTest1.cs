using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ModProductTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task  Test1()
        {
            var webFactory = new WebApplicationFactory<Program>();
            var httpClient = webFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("");
            var stringResult = await response.Content.ReadAsStringAsync();
        }
    }
}