namespace Calculator.Common;

public interface INamed
{
    public string Name { get; }
}

public interface IOperator : INamed
{
    public string Symbol { get; }
}

public interface IBinaryOperator : IOperator
{
    public string Calculate(string left, string right);
}

public interface IUnaryOperator : IOperator
{
    public string Calculate(string operand);
}