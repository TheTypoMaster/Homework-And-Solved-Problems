using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Implement a data structure that holds every performance in a venue in a city, such that:
        // Cities should remain in the order in which they were added, venues should be sorted alphabetically and performers should be unique (per venue) and also sorted alphabetically.
        // Using a Dictionary with sorted dictionary and sorted set inside it
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLifeSchedule = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        string[] input = Console.ReadLine().Trim().Split(';');
        
        while (input[0] != "END")
        {
            AddEntry(input, nightLifeSchedule);
            input = Console.ReadLine().Trim().Split(';');
        }

        PrintSchedule(nightLifeSchedule);
    }

    static void PrintSchedule(Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLifeSchedule)
    {
        foreach (var entry in nightLifeSchedule)
        {
            Console.WriteLine("{0}", entry.Key);
            foreach (var innerEntry in nightLifeSchedule[entry.Key])
            {
                Console.WriteLine("->{0}: {1}", innerEntry.Key, string.Join(", ", innerEntry.Value));
            }
        }
    }
    static void AddEntry(string[] input, Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLifeSchedule)
    {
        string city = input[0];
        string venue = input[1];
        string performer = input[2];

        if (!nightLifeSchedule.ContainsKey(input[0]))
        {
            nightLifeSchedule.Add(city, new SortedDictionary<string, SortedSet<string>>());
        }
        if (!nightLifeSchedule[city].ContainsKey(venue))
        {
            nightLifeSchedule[city].Add(venue, new SortedSet<string>());
            nightLifeSchedule[city][venue].Add(performer);
        }
        else
        {
            nightLifeSchedule[city][venue].Add(performer);
        }
    }
}
