
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter numbers separated by delimiters (e.g., '1,2' or '//;\n1;2').");
            string input = Console.ReadLine();

            StringCalculator calculator = new StringCalculator();

            int sum = calculator.Add(input);
            Console.WriteLine("The sum is: {0}", sum);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
