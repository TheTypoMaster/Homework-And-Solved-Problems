using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] text = "Hi,exe? ABBA! Hog fully a string. Bob".Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        SortedSet<string> palindromes = new SortedSet<string>();

        foreach (var item in text)
        {
            if (item.Substring(0, item.Length / 2).CompareTo(ReverseString(item.Substring(item.Length - item.Length / 2))) == 0)
            {
                palindromes.Add(item);
            }
        }
        Console.WriteLine(string.Join(", ", palindromes));
    }
    static string ReverseString(string stringToReverse)
    {
        char[] charArray = stringToReverse.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
