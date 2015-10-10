using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main(string[] args)
    {
        // Extract all e-mail addresses that match the specified pattern
        string pattern = @"(?:(?<=\s)|^)([a-z1-9]+[\-\._]?[a-z1-9]+)@(?:[a-z]+[\-]?[a-z]+)(:?\.[a-z]+[\-]?[a-z]+){1,}";
        Regex regex = new Regex(pattern);

        string text = Console.ReadLine();
        
        MatchCollection matches = regex.Matches(text);

        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }
    }
}
