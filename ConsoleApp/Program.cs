// See https://aka.ms/new-console-template for more information

using RomanTranslator;

var integer = RomanToInteger.Translate("MMCCXXIX");
var roman = IntegerToRoman.Translate(integer);

// Console.WriteLine(integer);
// Console.WriteLine(roman);

Console.WriteLine(RomanCalculator.RomanCalculator.Calculate("(MMMDCCXXIV - MMCCXXIX) * II + II*II"));
