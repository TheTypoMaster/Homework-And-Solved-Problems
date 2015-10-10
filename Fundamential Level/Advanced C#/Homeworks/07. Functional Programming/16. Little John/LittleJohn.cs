using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Dictionary<string, int> arrowsCount = new Dictionary<string, int>();
        arrowsCount.Add(">----->", 0);
        arrowsCount.Add(">>----->", 0);
        arrowsCount.Add(">>>----->>", 0);

        Regex[] arrows = new Regex[3]
        {
            new Regex(@"(?<=\b|\s|\n|^|)(>>>----->>)(?=\b|\s|\n|$|)"),
            new Regex(@"(?<=\b|\s|\n|^|)(>>----->)(?=\b|\s|\n|$|)"),
            new Regex(@"(?<=\b|\s|\n|^|)(>----->)(?=\b|\s|\n|$|)"),
        };

        string[] hay = new string[4];
        for (int i = 0; i < 4; i++)
        {
            hay[i] = Console.ReadLine();
        }

        // Get all arrows
        for (int rgx = 0; rgx < 3; rgx++)
        {
            for (int i = 0; i < hay.Length; i++)
            {
                MatchCollection matches = arrows[rgx].Matches(hay[i]);
                if (rgx == 0)
                {
                    arrowsCount[">>>----->>"] += matches.Count;
                    foreach (Match match in matches)
                    {
                        hay[i] = hay[i].Replace(match.Groups[0].Value, " ");
                    }
                }
                else if (rgx == 1)
                {
                    arrowsCount[">>----->"] += matches.Count;
                    foreach (Match match in matches)
                    {
                        hay[i] = hay[i].Replace(match.Groups[0].Value, " ");
                    }
                }
                else if (rgx == 2)
                {
                    arrowsCount[">----->"] += matches.Count;
                    foreach (Match match in matches)
                    {
                        hay[i] = hay[i].Replace(match.Groups[0].Value, " ");
                    }
                }
            }
        }

        // Get the concatenated arrows counts
        var count = arrowsCount
            .Select(x => x.Value);

        // Convert the decimal number to binary and append the reversed
        string dec = string.Join("", count);
        string bin = (Convert.ToString(int.Parse(dec), 2));
        StringBuilder builder = new StringBuilder();
        builder.Append(bin);

        for (int i = bin.Length - 1; i >= 0; i--)
        {
            builder.Append(bin[i]);
        }

        // Convert back to decimal
        int sum = 0;
        int power = builder.Length - 1;
        for (int i = 0; i < builder.Length; i++)
        {
            if (builder[i] == '1')
            {
                sum += (int)Math.Pow(2, power);
            }
            power--;
        }
        Console.WriteLine(sum);
    }
}
