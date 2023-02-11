namespace RomanTranslator;

public static class RomanToInteger
{
    private static readonly Dictionary<char, int> Dictionary = new()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    public static int Translate(string roman)
    {
        roman = roman.Replace("IV", "IIII")
            .Replace("IX", "VIIII")
            .Replace("XL", "XXXX")
            .Replace("XC", "LXXXX")
            .Replace("CD", "CCCC")
            .Replace("CM", "DCCCC");

        return roman.Sum(c => Dictionary[c]);
    }
}