namespace RomanExpression.Calculator.Interfaces;

/// <summary>
/// Калькулятор для выражений с римскими числами.
/// </summary>
public interface ICalculator
{
    /// <summary>
    /// Расчет выражения.
    /// </summary>
    /// <param name="expression">Выражение с римскими числами.</param>
    /// <returns>Результат выражения.</returns>
    public string Evaluate(string expression);
}