using System.Text;
using Pidgin;
using Pidgin.Expression;
using RomanTranslator;

namespace RomanCalculator;

public static class RomanCalculator
{
    public static string Calculate(string expression)
    {
        var length = expression.Length;
        
        for (var i = length - 1; i >= 0; --i)
        {
            if (!char.IsLetter(expression[i])) continue;

            var start = i;
            do
            {
                --i;
            } while (char.IsLetter(expression[i]));

            var end = i + 1;

            var sb = new StringBuilder();
            sb.Append(expression[..end]);
            sb.Append(RomanToInteger.Translate(expression.Substring(end, start - end + 1)));
            sb.Append(expression[(start + 1)..]);
            expression = sb.ToString();
        }

        expression = expression.Replace(" ", "");
        Console.WriteLine(expression);
        var operators = new[]
        {
            Operator.Prefix(Parser.Char('-').ThenReturn<Func<int, int>>(x => -x)),
            Operator.InfixL(Parser.Char('*').ThenReturn<Func<int, int, int>>((x, y) => x * y)),
            Operator.InfixL(Parser.Char('+').ThenReturn<Func<int, int, int>>((x, y) => x + y)),
            Operator.InfixL(Parser.Char('-').ThenReturn<Func<int, int, int>>((x, y) => x - y))
        };
        var parser = ExpressionParser.Build(
            expr => Parser.Num.Or(expr.Between(Parser.Char('('), Parser.Char(')'))),
            operators
        );
        var res = parser.ParseOrThrow(expression);
        
        return IntegerToRoman.Translate(res);
    }
}