using Pidgin;
using Pidgin.Expression;
using RomanExpression.Calculator.Interfaces;
using RomanExpression.Translator.Interfaces;

namespace RomanExpression.Calculator;

/// <summary>
/// Калькулятор для выражений с римскими числами.
/// </summary>
public sealed class RomanCalculator : ICalculator
{
    private readonly ITranslator _translator;
    private readonly Parser<char, int> _parser;

    private readonly OperatorTableRow<char, int>[] _operators =
    {
        Operator.Prefix(Parser.Char('-').ThenReturn<Func<int, int>>(x => -x)),
        Operator.InfixL(Parser.Char('*').ThenReturn<Func<int, int, int>>((x, y) => x * y)),
        Operator.InfixL(Parser.Char('+').ThenReturn<Func<int, int, int>>((x, y) => x + y)),
        Operator.InfixL(Parser.Char('-').ThenReturn<Func<int, int, int>>((x, y) => x - y))
    };

    /// <summary>
    /// Калькулятор для выражений с римскими числами.
    /// </summary>
    /// <param name="translator">Транслятор для римских чисел.</param>
    public RomanCalculator(ITranslator translator)
    {
        _translator = translator;
        _parser = ExpressionParser.Build(expr => Parser.Num.Or(expr.Between(Parser.Char('('),
                Parser.Char(')'))),
            _operators);
    }

    /// <summary>
    /// Расчет выражения.
    /// </summary>
    /// <param name="expression">Выражение с римскими числами.</param>
    /// <returns>Результат выражения.</returns>
    public string Evaluate(string expression)
    {
        expression = PrepareExpression(expression);

        var result = _parser.ParseOrThrow(expression);

        return _translator.IntegerToRoman(result);
    }

    /// <summary>
    /// Перевод выражения на integer и отчистка пробелов.
    /// </summary>
    /// <param name="expression">Выражение с римскими числами.</param>
    /// <returns>Выражение с integer и без пробелов.</returns>
    private string PrepareExpression(string expression)
    {
        expression = _translator.ReplaceAllRomanToInteger(expression);
        return expression.Replace(" ", "");
    }
}