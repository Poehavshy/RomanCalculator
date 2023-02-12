namespace RomanExpression.Translator.Tests;

public class TranslatorTests
{
    [Theory]
    [InlineData("X", 10)]
    [InlineData("XX", 20)]
    [InlineData("IV", 4)]
    [InlineData("VII", 7)]
    [InlineData("XIXVI", 25)]
    public void RomanToIntegerTheory(string roman, int expected)
    {
        var translator = new RomanTranslator();
        
        var result = translator.RomanToInteger(roman);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(10, "X")]
    [InlineData(17, "XVII")]
    [InlineData(101, "CI")]
    [InlineData(19, "XIX")]
    [InlineData(1, "I")]
    public void IntegerToRomanTheory(int integer, string expected)
    {
        var translator = new RomanTranslator();
        
        var result = translator.IntegerToRoman(integer);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("XIX + II", "19 + 2")]
    [InlineData("X + X - X", "10 + 10 - 10")]
    [InlineData("I - II * C", "1 - 2 * 100")]
    [InlineData("(MMMDCCXXIV - MMCCXXIX) * II", "(3724 - 2229) * 2")]
    [InlineData("(II + IV) - (X * III)", "(2 + 4) - (10 * 3)")]
    public void ReplaceAllRomanToIntegerTheory(string text, string expected)
    {
        var translator = new RomanTranslator();
        
        var result = translator.ReplaceAllRomanToInteger(text);
        
        Assert.Equal(expected, result);
    }
}