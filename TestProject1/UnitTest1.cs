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

    [Test]
    public async Task TestClass()
    {
        //Arrange
        
        
        var animal = new Animal(AnimalTypes.Bird);


        // f.ContinueWith((t) => Console.WriteLine("jhjhjh"));


        //Act
        var type = animal.AnimalType;

        //Assert
        Assert.AreEqual(AnimalTypes.Bird, type);
    }

    private async Task<int> VoidAsyncMethhod()
    {
        await Task.Run(() => Thread.Sleep(5000));
        return 0;
    }
}

enum AnimalTypes
{
    //Млекопитающее
    Mammal,
    //Насекомое
    Incept,
    //Рыба
    Fish,
    //Птицы
    Bird
}

class Animal
{
    public AnimalTypes AnimalType { get; set; }
    public Animal(AnimalTypes animalType): base()
    {
        AnimalType = animalType;
    }
}