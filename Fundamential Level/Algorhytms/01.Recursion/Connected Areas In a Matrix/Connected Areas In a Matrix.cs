using System;
using System.Collections.Generic;
using System.Linq;

class ConnectedAreasInMatrix
{
    // Print the total number of areas found in a matrix
    // Ordered first by the areas size and second by their position

    static bool isStart = false;
    static int currentRow = 0;
    static int currentCol = 0;
    static int size = 0;
    static Dictionary<string, int> areas = new Dictionary<string, int>();
    static Dictionary<int, string> sortedAreas = new Dictionary<int, string>();

    static char[,] matrix = new char[,] 
    {
        {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        {'*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' '},
        {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
    };

    static void Main(string[] args)
    {
        FindStart();
        while (isStart)
        {
            string coordinates = currentRow + ", " + currentCol; // Get the coordinates in a string format, so I can sort them later
            size = 0; // Set initial size
            GetAreaSize(currentRow, currentCol); // Recursively find the area size
            int area = size;
            FindStart(); // Check if there is more areas and get their coordinates
            areas.Add(coordinates, size); // Save coordinates and size
        }
        SortAreas();
        PrintResults();
    }
    static void FindStart() // Check if there is a starting cell and if there is, get its coordinates
    {
        isStart = false;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == ' ')
                {
                    currentRow = row;
                    currentCol = col;
                    isStart = true;
                    return;
                }
            }
        }
    }
    static void GetAreaSize(int currentRow, int currentCol)
    {
        size++; // Increase area size
        matrix[currentRow, currentCol] = '.'; // Mark cell as visited

        for (int direction = 1; direction <= 4; direction++)
        {
            // (1) UP
            if (direction == 1 && currentRow - 1 >= 0 && matrix[currentRow - 1, currentCol] == ' ')
            {
                GetAreaSize(currentRow - 1, currentCol);
            }
            // (2) RIGHT
            else if (direction == 2 && currentCol + 1 < matrix.GetLength(1) && matrix[currentRow, currentCol + 1] == ' ')
            {
                GetAreaSize(currentRow, currentCol + 1);
            }
            // (3) DOWN
            else if (direction == 3 && currentRow + 1 < matrix.GetLength(0) && matrix[currentRow + 1, currentCol] == ' ')
            {
                GetAreaSize(currentRow + 1, currentCol);
            }
            // (4) LEFT
            else if (direction == 4 && currentCol - 1 >= 0 && matrix[currentRow, currentCol - 1] == ' ')
            {
                GetAreaSize(currentRow, currentCol - 1);
            }
        }
    } // Recursively find the area size
    static void SortAreas()
    {
        // Havent learned about classes and objects yet so i'm implementing an ugly sorting method
        foreach (var item in areas)
        {
            if (!sortedAreas.ContainsKey(item.Value))
            {
                sortedAreas.Add(item.Value, item.Key);
            }
            else
            {
                sortedAreas[item.Value] = sortedAreas[item.Value] + "|" + item.Key;
            }
        }
    } // Don't look inside :)
    static void PrintResults() 
    {
        // Continuation of the ugly sorting and printing the results
        int counter = 1;
        Console.WriteLine("Total areas found: {0}", areas.Count);
        
        foreach (var pair in sortedAreas)
        {
            string[] coordinates = pair.Value.Split('|');
            Array.Sort(coordinates);
            foreach (var item in coordinates)
            {
                Console.WriteLine("Area #{0} at ({1}), size: {2}", counter, item, pair.Key);
                counter++;
            }
        }
    } // Print the result
}
