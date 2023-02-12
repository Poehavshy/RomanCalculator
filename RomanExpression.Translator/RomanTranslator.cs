using System.Text;
using RomanExpression.Translator.Interfaces;

namespace RomanExpression.Translator;

/// <summary>
/// Транслятор для римских чисел.
/// </summary>
public sealed class RomanTranslator : ITranslator
{
    private static readonly Dictionary<string, int> SimpleRomanIntegerValues = new()
    {
        {"I", 1},
        {"IV", 4},
        {"V", 5},
        {"IX", 9},
        {"X", 10},
        {"XL", 40},
        {"L", 50},
        {"XC", 90},
        {"C", 100},
        {"CD", 400},
        {"D", 500},
        {"CM", 900},
        {"M", 1000}
    };

    private static readonly Dictionary<string, string> RomanReplacementDictionary = new()
    {
        {"IV", "IIII"},
        {"IX", "VIIII"},
        {"XL", "XXXX"},
        {"XC", "LXXXX"},
        {"CD", "CCCC"},
        {"CM", "DCCCC"}
    };

    /// <summary>
    /// Переводит римское число в integer.
    /// </summary>
    /// <param name="roman">Римское число.</param>
    /// <returns>Число в integer.</returns>
    public int RomanToInteger(string roman)
    {
        var result = RomanReplacementDictionary.Aggregate(roman,
            (current, romanReplacement) =>
                current.Replace(romanReplacement.Key, romanReplacement.Value));

        return result.Sum(c => SimpleRomanIntegerValues[c.ToString()]);
    }

    /// <summary>
    /// Переводит integer в римское число.
    /// </summary>
    /// <param name="integer">Число в integer.</param>
    /// <returns>Римское число.</returns>
    public string IntegerToRoman(int integer)
    {
        var result = string.Empty;
        var i = SimpleRomanIntegerValues.Count - 1;

        while (integer != 0)
        {
            var romanIntegerValue = SimpleRomanIntegerValues.ElementAt(i);
            if (integer >= romanIntegerValue.Value)
            {
                integer -= romanIntegerValue.Value;
                result += romanIntegerValue.Key;
            }
            else
            {
                --i;
            }
        }

        return result;
    }

    /// <summary>
    /// Переводит все римские числа в тексте в integer.
    /// </summary>
    /// <param name="text">Текст с римскими числами.</param>
    /// <returns>Текст с числами в integer.</returns>
    public string ReplaceAllRomanToInteger(string text)
    {
        var length = text.Length;

        for (var i = length - 1; i >= 0; --i)
        {
            if (!char.IsLetter(text[i])) continue;

            var end = i;
            do
            {
                --i;
            } while (i >= 0 && char.IsLetter(text[i]));

            var start = i + 1;

            var integer = RomanToInteger(text.Substring(start, end - start + 1));
            text = ReplaceStringByIndexes(text, integer.ToString(), start, end);
        }

        return text;
    }

    /// <summary>
    /// Заменяет текст в указаных позициях на замещающий.
    /// </summary>
    /// <param name="text">Текст, в котором будет произведена замена.</param>
    /// <param name="replacement">Замещающий текст.</param>
    /// <param name="start">Начало замещения.</param>
    /// <param name="end">Конец замещения.</param>
    /// <returns>Текст с замещенным значением.</returns>
    private static string ReplaceStringByIndexes(string text, string replacement, int start, int end)
    {
        StringBuilder sb = new();
        sb.Append(text[..start]);
        sb.Append(replacement);
        sb.Append(text[(end + 1)..]);
        return sb.ToString();
    }
}