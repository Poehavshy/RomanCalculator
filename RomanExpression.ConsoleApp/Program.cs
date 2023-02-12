using RomanExpression.Calculator;
using RomanExpression.Translator;

Console.WriteLine(new RomanCalculator(new RomanTranslator()).Evaluate("(MMMDCCXXIV - MMCCXXIX) * II + II*II"));
