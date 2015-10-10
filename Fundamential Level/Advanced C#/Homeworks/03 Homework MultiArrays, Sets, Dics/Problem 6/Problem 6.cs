using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //Read some text from the console and print the number of occurances of each character inside of it
        string someText = "Did you know Math.Round rounds to the nearest even integer?";
        SortedDictionary<char, int> characterCount = new SortedDictionary<char, int>();

        for (int i = 0; i < someText.Length; i++)
        {
            if (characterCount.ContainsKey(someText[i]))
            {
                characterCount[someText[i]]++;
            }
            else
            {
                characterCount[someText[i]] = 1;
            }
        }

        foreach (var entry in characterCount)
        {
            Console.WriteLine("{0}: {1} time/s", entry.Key, entry.Value);
        }
    }
}
