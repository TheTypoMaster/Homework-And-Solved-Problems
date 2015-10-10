using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, long>> countries = new Dictionary<string, Dictionary<string, long>>();

        string command = Console.ReadLine();

        while (command != "report")
        {
            string[] commandArgs = command.Split(new char[] { '|' });
            string town = commandArgs[0];
            string country = commandArgs[1];
            string population = commandArgs[2];

            if (!countries.ContainsKey(country))
            {
                countries.Add(country, new Dictionary<string, long>());
            }

            countries[country].Add(town, long.Parse(population));

            command = Console.ReadLine();
        }

        //var ordered = countries
        //    .OrderByDescending(c => c.Value.Sum(x => x.Value));

        foreach (var pair in countries.OrderByDescending(c => c.Value.Sum(x => x.Value)))
        {
            Console.WriteLine("{0} (total population: {1})", pair.Key, pair.Value.Sum(x => x.Value));

            foreach (var innerPair in pair.Value.OrderByDescending(c => c.Value))
            {
                Console.WriteLine("=>{0}: {1}", innerPair.Key, innerPair.Value);
            }
        }
    }
}
