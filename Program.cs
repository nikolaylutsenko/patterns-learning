namespace PatternsLearning;

class Program
{
    static void Main(string[] args)
    {
        // BUILDER
        var builderA = new ProductABuilder<ProductA>();
        var builderB = new ProductBBuilder<ProductB>();

        var director = new Director();

        var productA = director.MakeProductA(builderA);
        var productB = director.MakeProductB(builderB);

        Console.WriteLine("Hello, World!");
    }
}
