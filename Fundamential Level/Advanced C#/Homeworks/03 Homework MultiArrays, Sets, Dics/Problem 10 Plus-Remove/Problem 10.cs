using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static List<string> input = new List<string>();
    static string[] output;

    static void Main()
    {
        string command = Console.ReadLine(); // Read board from the console
        while (command != "END")
        {
            input.Add(command);
            command = Console.ReadLine();
        }

        output = new string[input.Count]; // Copy the input to another matrix
        for (int i = 0; i < input.Count; i++)
        {
            output[i] = input[i];
        }

        for (int row = 0; row < input.Count - 2; row++) // For loop to check every possible top of a plus shape
        {
            for (int col = 1; col < input[row].Length; col++)
            {
                if (IsPlusShape(row, col)) // Check if the there is a plus shape
                {
                    output[row] = ReplaceCharacterWithSpaces(row, col, 1); // Replace chars with empty spaces for each row of the plus shape
                    output[row + 1] = ReplaceCharacterWithSpaces(row + 1, col, 3);
                    output[row + 2] = ReplaceCharacterWithSpaces(row + 2, col, 1);
                }
            }
        }

        for (int row = 0; row < input.Count; row++) // Remove white spaces so only symbols remain
		{
            output[row] = RemoveWhiteSpaces(row);
		}

        foreach (var item in output) // Print the output
        {
            Console.WriteLine(item);
        }
    }

    static bool IsPlusShape (int row, int col)
    {
        bool isPlusShape = true;
        char currentChar = Char.ToLower(input[row][col]);
        for (int i = col - 1; i <= col + 1; i++)
        {
            if (i < 0 || i > input[row + 1].Length - 1 || Char.ToLower(input[row + 1][i]) != currentChar)
            {
                isPlusShape = false;
            }
        }
        if (col > input[row + 2].Length - 1 || Char.ToLower(input[row + 2][col]) != currentChar)
        {
            isPlusShape = false;
        }
        return isPlusShape;
    }
    static string ReplaceCharacterWithSpaces (int row, int col, int charsToRemove)
    {
        StringBuilder builder = new StringBuilder();
        int index = charsToRemove == 1 ? 0 : 1;

        for (int i = 0; i < input[row].Length; i++)
        {
            if (i >= col - index && i <= col + index)
	        {
		        builder.Append(' ');
	        }
            else
            {
                builder.Append(output[row][i]);
            }
        }
        return builder.ToString();
    }
    static string RemoveWhiteSpaces(int row)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < output[row].Length; i++)
        {
            if (output[row][i] != ' ')
            {
                builder.Append(output[row][i]);
            }
        }
        return builder.ToString();
    }
}
