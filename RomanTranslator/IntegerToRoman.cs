namespace RomanTranslator;

public static class IntegerToRoman
{
    private static readonly string[] RomanLetters =
    {
        "M",
        "CM",
        "D",
        "CD",
        "C",
        "XC",
        "L",
        "XL",
        "X",
        "IX",
        "V",
        "IV",
        "I"
    };

    private static readonly int[] Numbers = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};

    public static string Translate(int integer)
    {
        var romanResult = string.Empty;
        var i = 0;
        while (integer != 0)
        {
            if (integer >= Numbers[i])
            {
                integer -= Numbers[i];
                romanResult += RomanLetters[i];
            }
            else
            {
                i++;
            }
        }

        return romanResult;
    }
}