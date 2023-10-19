using System;
using System.Collections.Generic;
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

        return SumNumbers(numberStrings);
    }

    private string UnescapeEscapedNewlines(string numbers)
    {
        return Regex.Unescape(numbers);
    }

    private char[] GetDelimiters(ref string numbers)
    {
        char[] delimiters = defaultDelimiters;
        if (numbers.StartsWith("//"))
        {
            string[] delimiterLine = numbers.Split('\n');
            numbers = delimiterLine[1];
            delimiters = ParseDelimiters(delimiterLine[0]);
        }
        return delimiters;
    }

    private char[] ParseDelimiters(string delimiterLine)
    {
        return delimiterLine.Substring(2).ToCharArray();
    }

    private string[] SplitNumbers(string numbers, char[] delimiters)
    {
        return numbers.Split(delimiters);
    }

    private void CheckForNegativeNumbers(string[] numberStrings)
    {
        List<int> negativeNumbers = new List<int>();
        foreach (string numberString in numberStrings)
        {
            int number = int.Parse(numberString);
            if (number < 0)
            {
                negativeNumbers.Add(number);
            }
        }
        if (negativeNumbers.Count > 0)
        {
            throw new Exception($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
        }
    }

    private int SumNumbers(string[] numberStrings)
    {
        int sum = 0;
        foreach (string numberString in numberStrings)
        {
            sum += int.Parse(numberString);
        }
        return sum;
    }
}
