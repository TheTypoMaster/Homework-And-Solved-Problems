using System;

class Program
{
    static void Main(string[] args)
    {
        //Write matrixes in two distinctive patterns
        int n = 5;
        int[,] matrix = new int[n, n];
        int index = 1;

        //Pattern A
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, col] = index;
                index++;
            }
        }

        Console.WriteLine("Pattern A:");
        PrintMatrix(matrix);
        index = 1;

        //Pattern B
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = index;
                    index++;
                }
            }
            else
            {
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    matrix[row, col] = index;
                    index++;
                }
            }
            
        }

        Console.WriteLine("\n Pattern B:");
        PrintMatrix(matrix);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,3}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
