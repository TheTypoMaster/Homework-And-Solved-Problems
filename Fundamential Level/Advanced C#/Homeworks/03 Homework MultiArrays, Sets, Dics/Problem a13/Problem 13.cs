using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        // Activity tracker
        // Read data from the console in format 24/07/2014 Angel 4600 etc.
        // Then print data in format -> month: user(distance), user(distance)
        // Example -> 7: Angel(4600), Pesho(3200)
        SortedDictionary<int, SortedDictionary<string, float>> activityTracker = new SortedDictionary<int, SortedDictionary<string, float>>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Trim().Split(' ');
            AddEntry(input, activityTracker);
        }
        PrintSchedule(activityTracker);
    }

    static void PrintSchedule(SortedDictionary<int, SortedDictionary<string, float>> activityTracker)
    {
        foreach (var entry in activityTracker)
        {
            // Can't think of better way to print nested dictionar's key and value, so i'm using StringBuilder...
            StringBuilder line = new StringBuilder();
            line.Append(entry.Key + ": ");
            foreach (var innerEntry in activityTracker[entry.Key])
            {
                line.Append(innerEntry.Key + "(" + innerEntry.Value + "), ");
            }
            line.Remove(line.Length - 2, 2);
            Console.WriteLine(line.ToString());
            line.Clear();
        }
    }
    static void AddEntry(string[] input, SortedDictionary<int, SortedDictionary<string, float>> activityTracker)
    {
        int month = DateTime.Parse(input[0], new CultureInfo("bg-BG")).Month;
        string user = input[1];
        float distance = float.Parse(input[2]);

        if (!activityTracker.ContainsKey(month)) // Check if there is instantiated inner dictionary and if there's not, make one
        {
            activityTracker.Add(month, new SortedDictionary<string, float>());
        }
        if (!activityTracker[month].ContainsKey(user)) // Check if there is already a user with the same name, so we dont lose data using .Add unnecessary
        {
            activityTracker[month].Add(user, distance);
        }
        else // If there is already a month, user and distance -> just sum distances
        {
            activityTracker[month][user] += distance;
        }
    }
}
