using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        int divisor = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        int length = text.Length;
        int arrSize = length % divisor == 0 ? length / divisor : length / divisor + 1; // get the size of the array
        string[] arr = new string[arrSize];

        if (length % divisor != 0) // fills up the text with spaces in the end
        {
            text = text + new string(' ', arrSize * divisor - length);
        }

        for (int i = 0; i < arrSize; i++) // slice the text and fill the array
        {
            arr[i] = text.Substring(i * divisor, divisor);
        }

        var result = arr // clone the array into a StringBuilder[]
            .Select(str => new StringBuilder().Append(str)).ToArray();

        ActivateTextGravity(result); // algo for chars to fall
        PrintResults(result); // print the results
    }

    private static void PrintResults(StringBuilder[] result)
    {
        Console.Write("<table>");
        foreach (var builder in result)
        {
            Console.Write("<tr>");
            var line = builder.ToString()
                .Select(ch => "<td>" + SecurityElement.Escape(ch.ToString()) + "</td>");
            Console.Write(string.Join("", line));
            Console.Write("</tr>");
        }
        Console.Write("</table>");
    }

    private static void ActivateTextGravity(StringBuilder[] result)
    {
        for (int i = result.Count() - 1; i >= 0; i--)
        {
            StringBuilder builder = new StringBuilder().Append("fasdfasdf");
            for (int j = 0; j < result[i].Length; j++)
            {
                int index = 1;
                if (result[i][j] == ' ')
                {
                    while (i - index >= 0 && result[i - index][j] == ' ')
                    {
                        index++;
                    }
                    if (i - index >= 0)
                    {
                        result[i][j] = result[i - index][j];
                        result[i - index][j] = ' ';
                    }
                }
            }
        }
    }
}
