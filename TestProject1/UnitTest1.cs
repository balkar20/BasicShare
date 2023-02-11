using IdentityProvider.Shared;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        //Arrange
        int one = 1;
        int two = 2;
        
        //Act
        int three = one + two;
        int four = one + 3;
        
        //Assert
        Assert.AreEqual(3, four);
    }

    [Test]
    public async Task TestAsync()
    {
        //Arrange

        int integer = await VoidAsyncMethhod();
        var i = 0;

        // f.ContinueWith((t) => Console.WriteLine("jhjhjh"));
        int one = 1;
        int two = 2;
        
        //Act
        int three = one + two;
        int four = one + 3;
        
        //Assert
        Assert.AreEqual(0, integer);
    }

    [Test]
    public async Task TestRecord()
    {
        //Arrange
        var productPricingViewModel = new PooperViewModel();

        var g = productPricingViewModel.Id;

        
        // f.ContinueWith((t) => Console.WriteLine("jhjhjh"));


        //Act


        //Assert
        // Assert.AreEqual(0, integer);
    }

    private async Task<int> VoidAsyncMethhod()
    {
        await Task.Run(() => Thread.Sleep(5000));
        return 0;
    }
}