using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StringCalculator
{
    private readonly char[] defaultDelimiters = { ',', '\n' };

    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        numbers = UnescapeEscapedNewlines(numbers);
        char[] delimiters = GetDelimiters(ref numbers);
        string[] numberStrings = SplitNumbers(numbers, delimiters);
        CheckForNegativeNumbers(numberStrings);

        return numberStrings.Where(n => int.TryParse(n, out _)).Sum(n => int.Parse(n));
    }

    private string UnescapeEscapedNewlines(string numbers)
    {
        return Regex.Unescape(numbers);
    }

    private char[] GetDelimiters(ref string numbers)
    {
        if (numbers.StartsWith("//"))
        {
            var delimiterLine = numbers.Split('\n');
            numbers = delimiterLine[1];
            return ParseDelimiters(delimiterLine[0]);
        }
        return defaultDelimiters;
    }

    private char[] ParseDelimiters(string delimiterLine)
    {
        return delimiterLine.Substring(2).ToCharArray();
    }

    private string[] SplitNumbers(string numbers, char[] delimiters)
    {
        return numbers.Split(delimiters);
    }

    private void CheckForNegativeNumbers(IEnumerable<string> numberStrings)
    {
        var negativeNumbers = numberStrings
            .Where(n => int.TryParse(n, out int value) && value < 0)
            .Select(n => int.Parse(n));

        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
        }
    }
}
