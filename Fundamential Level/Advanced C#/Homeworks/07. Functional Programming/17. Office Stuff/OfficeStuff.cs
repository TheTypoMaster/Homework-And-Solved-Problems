using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Using nested dictionaries
        Dictionary<string, Dictionary<string, int>> companies = new Dictionary<string, Dictionary<string, int>>();
        Regex pattern = new Regex(@"^\|\s*(\w+)\s*-\s*(\d+)\s*-\s*(\w+)s*\|\s*$");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++) // Populate the dictionary with data
        {
            string command = Console.ReadLine();

            string company = pattern.Match(command).Result("$1"); // Result from group 1
            string ammount = pattern.Match(command).Result("$2"); // Result from group 2
            string product = pattern.Match(command).Result("$3"); // Result from group 3

            if (!companies.ContainsKey(company))
            {
                companies.Add(company, new Dictionary<string, int>());
                companies[company].Add(product, int.Parse(ammount));
            }
            else
            {
                if (!companies[company].ContainsKey(product))
                {
                    companies[company].Add(product, int.Parse(ammount));
                }
                else
                {
                    companies[company][product] += int.Parse(ammount);
                }
            }
        }

        // Order by x.Key
        var ordered = companies
            .OrderBy(x => x.Key);

        // Print the results
        foreach (var company in ordered)
        {
            Console.Write("{0}: ", company.Key);

            Dictionary<string, int> innerDic = company.Value;

            var list = innerDic
                .Select(x => x.Key + "-" + x.Value);

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
