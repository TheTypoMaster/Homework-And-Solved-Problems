using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        string pattern = @"([A-Z][a-zA-Z]*)[^+a-zA-Z0-9]*\s*(\+*[0-9]+[0-9\(\)\/\.\- ]*[0-9]+)";
        string patternReplace = @"[\(\,\)\/\.\- ]";
        Regex rgx = new Regex(patternReplace);
        
        Dictionary<string, string> contacts = new Dictionary<string, string>();

        string command = Console.ReadLine();

        StringBuilder builder = new StringBuilder();

        while (command.Trim() != "END")
        {
            builder.Append(command);
            command = Console.ReadLine();
        }

        Match match = Regex.Match(builder.ToString(), pattern);

        while (match.Success)
        {
            string contact = match.Groups[1].Value;
            string number = match.Groups[2].Value;

            match = match.NextMatch();

            StringBuilder sb = new StringBuilder().Append(number);
            number = rgx.Replace(number, "");

            contacts[contact] = number;
        }

        if (contacts.Count != 0)
        {
            Console.Write("<ol>");
            foreach (var item in contacts)
            {
                Console.Write("<li><b>{0}:</b> {1}</li>", item.Key, item.Value);
            }
            Console.Write("</ol>");
        }
        else
        {
            Console.WriteLine("<p>No matches!</p>");
        }
    }
}
