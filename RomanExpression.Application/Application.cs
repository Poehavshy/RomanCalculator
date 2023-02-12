using RomanExpression.Application.Interfaces;
using RomanExpression.Calculator.Interfaces;

namespace RomanExpression.Application;

public class Application : IApplication
{
    private readonly ICalculator _calculator;

    public Application(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public void Start()
    {
        var result = _calculator.Evaluate("(MMMDCCXXIV - MMCCXXIX) * II");
        Console.WriteLine(result);
    }
}