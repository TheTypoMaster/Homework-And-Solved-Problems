using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string pattern = @"([a-zA-Z\d])\1+"; // Capture(group) only the first element of a pattern consisting of more than one repeating characters
        Regex regex = new Regex(pattern);

        string text = Console.ReadLine();
        string replacement = @"$1"; // Reference the group (which contains only the first element of matched pattern)

        string result = regex.Replace(text, replacement);
        Console.WriteLine(result);
    }
}