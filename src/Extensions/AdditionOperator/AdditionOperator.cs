namespace AdditionOperator;

using Calculator.Common;

[Addin]
public sealed class AdditionOperator : IBinaryOperator
{
    public string Symbol => "+";

    public string Name => "Addition";

    public string Calculate(string left, string right)
    {
        return (double.Parse(left) + double.Parse(right)).ToString();
    }
}