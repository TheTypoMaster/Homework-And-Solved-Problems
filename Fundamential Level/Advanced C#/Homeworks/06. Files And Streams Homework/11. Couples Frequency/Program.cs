using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Get the frequency of all consecutive pairs of numbers given on a single line
        string command = Console.ReadLine(); 
        int[] line = command.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

        Dictionary<string, int> couples = new Dictionary<string, int>();

        for (int i = 0; i < line.Length - 1; i++) // Iterate through every pair in the given list of numbers
        {
            string pair = line[i] + " " + line[i + 1];
            if (!couples.ContainsKey(pair))
            {
                couples.Add(pair, 1);
            }
            else
            {
                couples[pair] += 1;
            }
        }

        double sum = couples
            .Sum(x => x.Value); // Get all the occurances so i can calculate the percentage

        foreach (var item in couples) // Printing the results
        {
            Console.WriteLine("{0} -> {1:F2}%", item.Key, (item.Value / sum) * 100);
        }
    }
}
