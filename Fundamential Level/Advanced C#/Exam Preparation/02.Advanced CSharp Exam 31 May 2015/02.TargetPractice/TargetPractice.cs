using System;
using System.Linq;

class TargetPractice
{
    static void Main()
    {
        // Read dimensions
        int[] dimensions = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];

        // Fill the matrix
        char[,] matrix = new char[rows, cols];
        string snake = Console.ReadLine();
        FillMatrix(matrix, snake);

        // Read shot coordinates
        int[] shot = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        DestroyTarget(matrix, shot);

        // Characters Gravity
        CharactersGravity(matrix);
        PrintMatrix(matrix);

    }

    private static void CharactersGravity(char[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == ' ')
                {
                    int index = 1;
                    while (i - index >= 0 && matrix[i - index, j] == ' ')
                    {
                        index++;
                    }
                    if (i - index >= 0)
                    {
                        matrix[i, j] = matrix[i - index, j];
                        matrix[i - index, j] = ' ';
                    }
                }
            }
        }
    }

    private static void DestroyTarget(char[,] matrix, int[] shot)
    {
        int shotRow = shot[0];
        int shotCol = shot[1];
        int shotRadius = shot[2];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if ((Math.Pow(i - shotRow, 2) + Math.Pow(j - shotCol, 2)) <= Math.Pow(shotRadius, 2))
                {
                    matrix[i, j] = ' ';
                }
            }
        }
    }

    private static void FillMatrix(char[,] matrix, string snake)
    {
        int counter = 0;
        int direction = 0;
        for (int i = matrix.GetLength(0) - 1; i >=0; i--)
        {
            for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
            {
                if (direction % 2 == 0)
                {
                    matrix[i, j] = snake[counter % snake.Length];
                }
                else
                {
                    matrix[i, (matrix.GetLength(1) - 1 - j)] = snake[counter % snake.Length];
                }
                counter++;
            }
            direction++;
        }
    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j]);
            }
            Console.WriteLine();
        }
    }
}
