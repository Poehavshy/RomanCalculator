using RomanExpression.Translator;

namespace RomanExpression.Calculator.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData("(MMMDCCXXIV - MMCCXXIX) * II", "MMCMXC")]
    [InlineData("X + X", "XX")]
    [InlineData("XX - I", "XIX")]
    [InlineData("X * X", "C")]
    [InlineData("X + X - (II * IV)", "XII")]
    public void EvaluateTheory(string expression, string expected)
    {
        var calculator = new RomanCalculator(new RomanTranslator());
        
        var result = calculator.Evaluate(expression);
        
        Assert.Equal(expected, result);
    }
}