using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class TextTransformer
{
    static void Main()
    {
        string command = Console.ReadLine();
        StringBuilder builder = new StringBuilder();
        List<string> results = new List<string>();

        while (command != "burp")
        {
            builder.Append(command);
            command = Console.ReadLine();
        }

        string text = Regex.Replace(builder.ToString(), @"\s+", " ");
        string pattern = @"(?<capt>\$|%|&|')([^$%&']+?)(\k<capt>)";

        Match match = Regex.Match(text, pattern);

        while (match.Success)
        {
            string result = TransfortmText(match);
            results.Add(result);
            match = match.NextMatch();
        }
        Console.WriteLine(string.Join(" ", results));
    }

    private static string TransfortmText(Match match)
    {
        int special = 0;

        switch (match.Groups["capt"].Value.ToCharArray()[0])
	    {
            case '$': special = 1; break;
            case '%': special = 2; break;
            case '&': special = 3; break;
            case '\'': special = 4; break;
		    default: break;
	    }

        StringBuilder sb = new StringBuilder().Append(match.Groups[1].Value);

        for (int i = 0; i < sb.Length; i++)
        {
            if (i % 2 == 0)
            {
                sb[i] = Convert.ToChar(sb[i] + special);
            }
            else
            {
                sb[i] = Convert.ToChar(sb[i] - special);
            }
        }

        return sb.ToString();
    }
}
