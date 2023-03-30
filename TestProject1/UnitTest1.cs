using System.Text.RegularExpressions;
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
    public void Test2()
    {
        //Arrange
        int one = 1;
        int two = 2;
        
        //Act
        var s = new S();
        using (s)
        {
            Console.WriteLine(s.GetDispose());
        }
        Console.WriteLine(s.GetDispose());
        
        //Assert
        // Assert.AreEqual(3, four);
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

    [Test]
    public  void TestRegex()
    {
        //Arrange

        var vm = "ViewModel";
        var vmo = "LoginViewModel";
        var expected = "login";
        // var regex2 = 
        var nm = typeof(TestViewModel).ToString();
        var result = vmo.Replace(vm, "" ).ToLower();


        // f.ContinueWith((t) => Console.WriteLine("jhjhjh"));


        //Act
        // cooker.Feed(fish, "Plancton");

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public  void TestCooker()
    {
        //Arrange


        Cooker cooker = new Cooker();
        
        Animal incept = new Incept(AnimalTypes.Incept);
        Animal fish = new Fish(AnimalTypes.Fish);

        // f.ContinueWith((t) => Console.WriteLine("jhjhjh"));


        //Act
        cooker.Feed(fish, "Plancton");
        
        //Assert
        // Assert.AreEqual(UserClaimEnum.Dev.ToString(), type);
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

class Animal: IAnimal
{
    public AnimalTypes AnimalType { get; set; }
    public Animal(AnimalTypes animalType): base()
    {
        AnimalType = animalType;
    }

    public virtual void Eat(string foodName)
    {
       Console.WriteLine($"I am animal wich eats {foodName}");
    }
}

class Incept: Animal
{
    public Incept(AnimalTypes animalType) : base(animalType)
    {
    }

    public override void Eat(string foodName)
    {
        base.Eat(foodName);
        if (foodName.Contains("Weed"))
        {
            Console.WriteLine("Yeah i love Weed");
        }else
        {
            Console.WriteLine("Fuck you");
        }
    }
}

class Fish: Animal
{
    public Fish(AnimalTypes animalType) : base(animalType)
    {
    }

    public override void Eat(string foodName)
    {
        base.Eat(foodName);
        if (foodName.Contains("Plancton"))
        {
            Console.WriteLine("Yeah i love plancton");
        }else
        {
            Console.WriteLine("Fuck you");
        }
        
    }
}

interface IAnimal
{
    AnimalTypes AnimalType { get; set; }
    void Eat(string foodName);
}

class Cooker
{
    public void Feed(IAnimal animal, string foodName)
    {
        animal.Eat(foodName);
    }
}

public struct S : IDisposable
{
    private bool dispose;
    public void Dispose()
    {
        dispose = true;
    }
    public bool GetDispose()
    {
        return dispose;
    }
}

public class TestViewModel
{
    
}