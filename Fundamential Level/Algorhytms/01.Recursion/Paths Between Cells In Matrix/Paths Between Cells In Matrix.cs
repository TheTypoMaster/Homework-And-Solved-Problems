using System;
using System.Collections.Generic;

class PathsBetweenCells
{
    // Find all paths in a matrix of chars from the 's' to the 'e'
    static int currentRow = 0;
    static int currentCol = 0;
    static List<char> path = new List<char>();
    static int pathsFound = 0;

    static char[,] matrix = new char[,] 
        {
            {'s', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', 'e', ' ', ' ', ' '},
            {' ', ' ', ' ', '*', ' ', ' '},
        };

    static void Main(string[] args)
    {
        FindStart(); // Find the 's'
        FindPaths(currentRow, currentCol); // FindAllPaths
        Console.WriteLine("Total paths found: {0}", pathsFound); // Print total count of paths
    }

    static void FindPaths(int currentRow, int currentCol) // Recursive search for a path
    {
        if (matrix[currentRow, currentCol] == 'e') // if we find an exit - > Print path
        {
            Console.WriteLine(string.Join("", path));
            pathsFound++;
        }
        else
        {
            // 1 = up; 2 = right; 3 = down; 4 = left;
            for (int direction = 1; direction <= 4; direction++)
            {
                // (1) UP
                if (direction == 1 && currentRow - 1 >= 0 &&
                    (matrix[currentRow - 1, currentCol] == ' ' || matrix[currentRow - 1, currentCol] == 'e'))
                {
                    path.Add('U');
                    matrix[currentRow, currentCol] = '.';
                    FindPaths(currentRow - 1, currentCol);
                    path.RemoveAt(path.Count - 1);
                    matrix[currentRow, currentCol] = ' ';
                }
                // (2) RIGHT
                else if (direction == 2 && currentCol + 1 < matrix.GetLength(1) &&
                    (matrix[currentRow, currentCol + 1] == ' ' || matrix[currentRow, currentCol + 1] == 'e'))
                {
                    path.Add('R');
                    matrix[currentRow, currentCol] = '.';
                    FindPaths(currentRow, currentCol + 1);
                    path.RemoveAt(path.Count - 1);
                    matrix[currentRow, currentCol] = ' ';
                }
                // (3) DOWN
                else if (direction == 3 && currentRow + 1 < matrix.GetLength(0) &&
                    (matrix[currentRow + 1, currentCol] == ' ' || matrix[currentRow + 1, currentCol] == 'e'))
                {
                    path.Add('D');
                    matrix[currentRow, currentCol] = '.';
                    FindPaths(currentRow + 1, currentCol);
                    path.RemoveAt(path.Count - 1);
                    matrix[currentRow, currentCol] = ' ';
                }
                // (4) LEFT
                else if (direction == 4 && currentCol - 1 >= 0 && 
                    (matrix[currentRow, currentCol - 1] == ' ' || matrix[currentRow, currentCol - 1] == 'e'))
                {
                    path.Add('L');
                    matrix[currentRow, currentCol] = '.';
                    FindPaths(currentRow, currentCol - 1);
                    path.RemoveAt(path.Count - 1);
                    matrix[currentRow, currentCol] = ' ';
                }
            }
        }
    }
    static void FindStart() // Find the 's' in the matrix 
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 's')
                {
                    currentRow = row;
                    currentCol = col;
                    break;
                }
            }
        }
    }
}