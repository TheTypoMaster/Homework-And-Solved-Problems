using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Search the input for the specified patter, which is {letter}{some digits}{letter}
        string pattern = @"[a-zA-Z]\d+[a-zA-Z]";
        Regex regex = new Regex(pattern);
        MatchCollection matches = Regex.Matches(Console.ReadLine(), @"[a-zA-Z]\d+[a-zA-Z]");

        // Fill in a list with all entries matching the pattern
        List<string> entries = new List<string>();

        foreach (Match match in matches)
        {
            entries.Add(match.ToString());
        }
        
        // Get the sum of all entries
        double sum = 0d;
        foreach (string entry in entries)
        {
            sum += CalculateEntryValue(entry);
        }
        
        // Print the sum
        Console.WriteLine("{0:F2}", sum);
    }

    static double CalculateEntryValue(string entry)
    {
        string number = entry.Substring(1, entry.Length - 2);
        char letterBefore = entry[0];
        char letterAfter = entry[entry.Length - 1];
        double result = double.Parse(number);

        if (char.IsUpper(letterBefore))
        {
            // If char is uppercase -> Divide by the letters position in the alphabet
            result /= letterBefore - 64;
        }
        else if (char.IsLower(letterBefore))
        {
            // If char is lowercase -> Multiply by the letters position in the alphabet
            result *= letterBefore - 96;
        }

        if (char.IsUpper(letterAfter))
        {
            result -= letterAfter - 64;
        }
        else if (char.IsLower(letterAfter))
        {
            result += letterAfter - 96;
        }

        return result;
    }
}
