using System.Resources;

namespace PatternsLearning;

public interface IBuilder<TResult> where TResult : new()
{
    public void Reset();
    public void BuildStepA();
    public void BuildStepB();
    public TResult GetResult();
}

public class ProductABuilder<TResult> : IBuilder<TResult> where TResult : ProductA, new()
{
    private TResult _productA = new();

    public void BuildStepA()
    {
        _productA.Name = "Foo";
    }

    public void BuildStepB()
    {
        _productA.Number = 42;
    }

    public TResult GetResult()
    {
        return _productA;
    }

    public void Reset()
    {
        _productA = new TResult();
    }
}

public class ProductBBuilder<TResult> : IBuilder<TResult> where TResult : ProductB, new()
{
    private TResult _product = new();

    public void BuildStepA()
    {
        _product.Id = Guid.NewGuid();
    }

    public void BuildStepB()
    {
        _product.Alias = "Awesome!";
    }

    public TResult GetResult()
    {
        return _product;
    }

    public void Reset()
    {
        _product = new TResult();
    }
}

// this is optional
public class Director
{
    public ProductA MakeProductA(ProductABuilder<ProductA> builder)
    {
        builder.BuildStepA();
        builder.BuildStepB();

        return builder.GetResult();
    }

    public ProductB MakeProductB(ProductBBuilder<ProductB> builder)
    {
        builder.BuildStepA();
        builder.BuildStepB();

        return builder.GetResult();
    }
}

public class ProductA
{
    public string Name { get; set; }
    public int Number { get; set; }
}

public class ProductB
{
    public Guid Id { get; set; }
    public string Alias { get; set; }
}