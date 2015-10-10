using System;

class Program
{
    static string maxElement = "";
    static int sequenceLength = 0;
    static int longestSequence = 0;
    static string[,] matrix = {
                                {"ha", "ha", "ha", "ho"},
                                {"ha", "ho", "ho", "xx"},
                                {"ho", "ho", "a", "xx"},
                                {"ho", "ho", "a", "xx"},
                            };

    static void Main()
    {
        // Search for the longest sequence of repeating elements in a matrix. Horizontally, vertically and diagonally.

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                //Check horizontal
                sequenceLength = CheckHorizontal(row, col);
                if (sequenceLength > longestSequence)
                {
                    longestSequence = sequenceLength;
                    maxElement = matrix[row, col];
                }

                //Check vertical
                sequenceLength = CheckVertical(row, col);
                if (sequenceLength > longestSequence)
                {
                    longestSequence = sequenceLength;
                    maxElement = matrix[row, col];
                }

                //Check left diagonal
                sequenceLength = CheckLeftDiagonal(row, col);
                if (sequenceLength > longestSequence)
                {
                    longestSequence = sequenceLength;
                    maxElement = matrix[row, col];
                }

                //Check right diagonal;
                sequenceLength = CheckRightDiagonal(row, col);
                if (sequenceLength > longestSequence)
                {
                    longestSequence = sequenceLength;
                    maxElement = matrix[row, col];
                }
            }
        }

        for (int i = 0; i < longestSequence; i++) // Print the longest sequence and the number of occurances
        {
            Console.Write(maxElement);
            if (i < longestSequence - 1)
            {
                Console.Write(", ");
            }
            else
            {
                Console.WriteLine();
            }
        }
    }

    static int CheckHorizontal(int row, int col)
    {
        int counter = 1;
        bool isNextElement = col + 1 < matrix.GetLength(1);
        while (isNextElement && matrix[row, col + 1] == matrix[row, col])
        {
            counter++;
            col++;
            isNextElement = col + 1 < matrix.GetLength(1);
        }
        return counter;
    }
    static int CheckVertical(int row, int col)
    {
        int counter = 1;
        bool isNextElement = row + 1 < matrix.GetLength(0);
        while (isNextElement && matrix[row + 1, col] == matrix[row, col])
        {
            counter++;
            row++;
            isNextElement = row + 1 < matrix.GetLength(0);
        }
        return counter;
    }
    static int CheckLeftDiagonal(int row, int col)
    {
        int counter = 1;
        bool isNextElement = row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1);
        while (isNextElement && matrix[row + 1, col + 1] == matrix[row, col])
        {
            counter++;
            row++;
            col++;
            isNextElement = row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1);
        }
        return counter;
    }
    static int CheckRightDiagonal(int row, int col)
    {
        int counter = 1;
        bool isNextElement = row + 1 < matrix.GetLength(0) && col - 1 >= 0;
        while (isNextElement && matrix[row + 1, col - 1] == matrix[row, col])
        {
            counter++;
            row++;
            col--;
            isNextElement = row + 1 < matrix.GetLength(0) && col - 1 >= 0;
        }
        return counter;
    }
}
