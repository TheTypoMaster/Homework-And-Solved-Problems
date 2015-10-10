using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class OlympicsAreComming
{
    static void Main()
    {
        string command = Console.ReadLine();
        Dictionary<string, Dictionary<string, int>> dic = new Dictionary<string, Dictionary<string, int>>();

        while (command.ToLower() != "report")
        {
            // read until "report"
            string[] commandArgs = command.Split('|');
            string country = Regex.Replace(commandArgs[1].Trim(), @"\s+", " ");
            string athlete = Regex.Replace(commandArgs[0].Trim(), @"\s+", " ");

            // add to dictionary
            if (!dic.ContainsKey(country))
            {
                dic.Add(country, new Dictionary<string, int>());
            }
 
            if (!dic[country].ContainsKey(athlete))
            {
                dic[country].Add(athlete, 1);
            }
            else
            {
                dic[country][athlete] += 1;
            }

            command = Console.ReadLine();
        }

        var ordered = dic
            .OrderByDescending(country => country.Value.Sum(athlete => athlete.Value));

        foreach (var country in ordered)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins", country.Key, country.Value.Count(), country.Value.Sum(ath => ath.Value));
        }
    }
}
