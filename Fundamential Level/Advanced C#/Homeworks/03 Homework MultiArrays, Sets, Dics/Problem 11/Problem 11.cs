using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static List<string> input = new List<string>();
    static string[] output;

    static void Main(string[] args)
    {
        string command = Console.ReadLine(); // Read rotation in format Rotate(xx)
        int rotation = int.Parse(Regex.Match(command, @"\d+").Value); // Get rotation degrees from the console using regex
        ReadMatrix(); // Fill the matrix from the console
        int longestString = GetLongestStringLength(); // using this to calculate dimensions of the output matrix

        switch (rotation % 360)
        {
            case 0: PrintMatrix(input); break;
            case 90: Rotate90(longestString); PrintMatrix(output); break;
            case 180: Rotate180(longestString); PrintMatrix(output); break;
            case 270: Rotate270(longestString); PrintMatrix(output); break;
            default: break;
        }
    }

    
    // Three methods for rotation in 90, 180 and 270 degrees
    static void Rotate90(int longestString)
    {
        StringBuilder builder = new StringBuilder();
        output = new string[longestString];

        for (int col = 0; col < longestString; col++)
        {
            for (int row = input.Count - 1; row >= 0; row--)
            {
                if (col >= input[row].Length)
                {
                    builder.Append(' ');
                }
                else
                {
                    builder.Append(input[row][col]);
                }
            }
            output[col] = builder.ToString();
            builder.Clear();
        }
    }
    static void Rotate180(int longestString)
    {
        output = new string[input.Count];
        StringBuilder builder = new StringBuilder();

        for (int row = 0; row < input.Count; row++)
        {
            for (int col = longestString - 1; col >= 0; col--)
            {
                if (col >= input[row].Length)
                {
                    builder.Append(' ');
                }
                else
                {
                    builder.Append(input[row][col]);
                }
            }
            output[input.Count - row - 1] = builder.ToString();
            builder.Clear();
        }
    }
    static void Rotate270(int longestString)
    {
        output = new string[longestString];
        StringBuilder builder = new StringBuilder();

        for (int col = longestString - 1; col >= 0; col--)
        {
            for (int row = 0; row < input.Count; row++)
            {
                if (col >= input[row].Length)
                {
                    builder.Append(' ');
                }
                else
                {
                    builder.Append(input[row][col]);
                }
            }
            output[longestString - col - 1] = builder.ToString();
            builder.Clear();
        }
    }
    // Methods for reading and printing the matrix
    static void PrintMatrix(List<string> matrix)
    {
        foreach (var item in matrix)
        {
            Console.WriteLine(item);
        }
    }
    static void PrintMatrix(string[] matrix)
    {
        foreach (var item in matrix)
        {
            Console.WriteLine(item);
        }
    }
    static void ReadMatrix()
    {
        string command = Console.ReadLine();
        while (command != "END")
        {
            input.Add(command);
            command = Console.ReadLine();
        }
    }
    static int GetLongestStringLength()
    {
        int maxLength = Int32.MinValue;
        foreach (var item in input)
        {
            if (item.Length > maxLength)
            {
                maxLength = item.Length;
            }
        }
        return maxLength;
    } // Using this to calculate output matrix dimensions
}
