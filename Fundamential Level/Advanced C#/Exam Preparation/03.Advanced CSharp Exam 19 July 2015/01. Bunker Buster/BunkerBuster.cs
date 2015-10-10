using System;
using System.Linq;

class BunkerBuster
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];

        int[,] field = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            int[] row = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            for (int j = 0; j < cols; j++)
            {
                field[i, j] = row[j];
            }
        }

        string command = Console.ReadLine();
        while (command != "cease fire!")
        {
            string[] target = command.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            DropBomb(target, field);
            command = Console.ReadLine();
        }

        int cellsDestroyed = CountCells(field);
        Console.WriteLine("Destroyed bunkers: " + cellsDestroyed);
        Console.WriteLine("Damage done: {0:F1} %", (double)cellsDestroyed / (rows * cols) * 100);
    }

    private static int CountCells(int[,] field)
    {
        int count = 0;
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] <= 0)
                {
                    count++;
                }
            }
        }
        return count;
    }

    private static void DropBomb(string[] target, int[,] field)
    {
        int row = int.Parse(target[0]);
        int col = int.Parse(target[1]);
        int damage = char.Parse(target[2]);

        int rowStart = Math.Max(0, row - 1);
        int rowEnd = Math.Min(field.GetLength(0) - 1, row + 1);
        int colStart = Math.Max(0, col - 1);
        int colEnd = Math.Min(field.GetLength(1) - 1, col + 1);

        for (int i = rowStart; i <= rowEnd; i++)
        {
            for (int j = colStart; j <= colEnd; j++)
            {
                if (i == row && j == col)
	            {
                    field[i, j] -= damage;
	            }
                else
                {
                    field[i, j] -= (int)Math.Ceiling((double)damage / 2d);
                }
            }
        }
    }
}
