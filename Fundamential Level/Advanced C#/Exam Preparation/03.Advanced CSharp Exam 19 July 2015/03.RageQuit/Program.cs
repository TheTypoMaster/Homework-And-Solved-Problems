using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string message = Console.ReadLine();
        string pattern = @"([\D]+)([\d]+)";
        StringBuilder result = new StringBuilder();

        Match match = Regex.Match(message, pattern);

        while (match.Success)
        {
            string part = match.Groups[1].Value.ToUpper();
            int multiplier = int.Parse(match.Groups[2].Value);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < multiplier; i++)
            {
                sb.Append(part);
            }

            result.Append(sb.ToString());
            match = match.NextMatch();
        }

        var uniqueSymbols = result.ToString().Distinct().Count();
        Console.WriteLine("Unique symbols used: " + uniqueSymbols);
        Console.WriteLine(result.ToString());
    }
}