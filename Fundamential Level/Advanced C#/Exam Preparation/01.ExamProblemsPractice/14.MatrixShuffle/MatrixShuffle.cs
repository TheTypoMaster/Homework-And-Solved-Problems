using System;
using System.Text;
using System.Text.RegularExpressions;

class MatrixShuffle
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); // reading the input
        string text = Console.ReadLine();
        char[,] matrix = new char[n, n];

        ClockWiseSpiralFill(matrix, text, 0, 0);
        string result = ExtractStringInChessboardPattern(matrix); // extract the result from the filled matrix
        string copy = Regex.Replace(result.ToLower(), @"[^a-z]+", ""); // replace all non letters with empty string

        bool palindrome = CheckIfPalindrome(copy); // check if the result is palindrome

        if (palindrome) // print the result
        {
            Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", result);
        }
        else
        {
            Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", result);
        }
    }

    private static bool CheckIfPalindrome(string result)
    {
        bool palindrome = true;

        for (int i = 0; i < result.Length / 2; i++)
        {
            if (result[i] != result[result.Length - i - 1])
            {
                palindrome = false;
                return palindrome;
            }
        }
        return palindrome;
    }

    private static string ExtractStringInChessboardPattern(char[,] matrix)
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < 2; i++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (i % 2 == 0 && row % 2 == 0 && col % 2 == 0) // white cells
                    {
                        builder.Append(matrix[row, col]);
                    }
                    else if (i % 2 == 0 && row % 2 == 1 && col % 2 == 1) // white cells
                    {
                        builder.Append(matrix[row, col]);
                    }
                    else if (i % 2 == 1 && row % 2 == 0 && col % 2 == 1) // black cells
                    {
                        builder.Append(matrix[row, col]);
                    }
                    else if (i % 2 == 1 && row % 2 == 1 && col % 2 == 0) // black cells
                    {
                        builder.Append(matrix[row, col]);
                    }
                }
            }
        }

        return builder.ToString();
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void ClockWiseSpiralFill(char[,] matrix, string text, int row, int col, int index = 0)
    {
        if (index >= matrix.GetLength(0) * matrix.GetLength(1))
        {
            return;
        }
        if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] == '\0')
	    {
            matrix[row, col] = text[index % text.Length];
            index++;
	    }
        while (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == '\0') // right
        {
            matrix[row, col + 1] = text[index % text.Length];
            index++;
            col++;
        }
        while (row + 1 < matrix.GetLength(1) && matrix[row + 1, col] == '\0') // down
        {
            matrix[row + 1, col] = text[index % text.Length];
            index++;
            row++;
        }
        while (col - 1 >= 0 && matrix[row, col - 1] == '\0') // left
        {
            matrix[row, col - 1] = text[index % text.Length];
            index++;
            col--;
        }
        while (row - 1 >= 0 && matrix[row - 1, col] == '\0') // up
        {
            matrix[row - 1, col] = text[index % text.Length];
            index++;
            row--;
        }
        ClockWiseSpiralFill(matrix, text, row, col, index);
    } // recursive clockwise spiral fill of the matrix
}
