using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //Find the best platform (3x3) in a matrix with given dimensions
        int[] dimensions = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
        int[,] matrix = new int[dimensions[0], dimensions[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] inputLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = inputLine[col];
            }
        }

        int maxSum = Int32.MinValue;
        int maxRowIndex = 0;
        int maxColIndex = 0;

        //search for best platform
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                if (SumOfElements(matrix, row, col) > maxSum)
                {
                    maxSum = SumOfElements(matrix, row, col);
                    maxRowIndex = row;
                    maxColIndex = col;
                }
            }
        }

        Console.WriteLine("Sum = " + maxSum);
        PrintMatrix(matrix, maxRowIndex, maxColIndex);
    }
    static int SumOfElements(int[,] matrix, int rowIndex, int colIndex)
    {
        int sum = 0;
        for (int row = rowIndex; row < rowIndex + 3; row++)
        {
            for (int col = colIndex; col < colIndex + 3; col++)
            {
                sum += matrix[row, col];
            }
        }
        return sum;
    }
    static void PrintMatrix(int[,] matrix, int rowIndex, int colIndex)
    {
        for (int row = rowIndex; row < rowIndex + 3; row++)
        {
            for (int col = colIndex; col < colIndex + 3; col++)
            {
                Console.Write("{0,3}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}