namespace RomanExpression.Translator.Interfaces;

/// <summary>
/// Транслятор для римских чисел.
/// </summary>
public interface ITranslator
{
    /// <summary>
    /// Переводит римское число в integer.
    /// </summary>
    /// <param name="roman">Римское число.</param>
    /// <returns>Число в integer.</returns>
    public int RomanToInteger(string roman);
    
    /// <summary>
    /// Переводит integer в римское число.
    /// </summary>
    /// <param name="integer">Число в integer.</param>
    /// <returns>Римское число.</returns>
    public string IntegerToRoman(int integer);
    
    /// <summary>
    /// Переводит все римские числа в тексте в integer.
    /// </summary>
    /// <param name="text">Текст с римскими числами.</param>
    /// <returns>Текст с числами в integer.</returns>
    public string ReplaceAllRomanToInteger(string text);
}