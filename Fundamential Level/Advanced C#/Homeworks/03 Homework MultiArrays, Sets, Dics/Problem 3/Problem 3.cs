using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //Read a matrix from the console and then perform swaps according to commands. Check if commands are in the valid format.
        int rows = int.Parse(Console.ReadLine()); //Read dimensions of the matrix
        int cols = int.Parse(Console.ReadLine());

        string[,] matrix = new string[rows, cols]; //Read the matrix according to dimensions
        ReadMatrix(matrix);

        while (true) //Program loop
        {
            string[] command = Console.ReadLine().Trim().Split(' ').ToArray(); //Read command line
            if (command[0] == "END")
            {
                break;
            }
            int[] coordinates = new int[command.Length - 1];
            bool validCommand = (command[0] == "swap") && (command.Length == 5);
            if (validCommand) //Validate command
            {
                for (int i = 0; i < command.Length - 1; i++)
                {
                    coordinates[i] = int.Parse(command[i + 1]);
                }
                if (ValidCoordiantes(coordinates, matrix)) //Validate coordinates
                {
                    Swap(matrix, coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }

    static void ReadMatrix(string[,] matrix) //Read matrix from the console
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }
    }
    static bool ValidCoordiantes (int[] coordiantes, string[,] matrix) // Return a bool value for validating coordinates
    {
        bool validCoordinates = true;
        if (coordiantes[0] >= matrix.GetLength(0) || coordiantes[0] < 0)
        {
            validCoordinates = false;
        }
        if (coordiantes[1] >= matrix.GetLength(1) || coordiantes[1] < 0)
        {
            validCoordinates = false;
        }
        if (coordiantes[2] >= matrix.GetLength(0) || coordiantes[2] < 0)
        {
            validCoordinates = false;
        }
        if (coordiantes[3] >= matrix.GetLength(1) || coordiantes[3] < 0)
        {
            validCoordinates = false;
        }
        return validCoordinates;
    }
    static void Swap(string[,] matrix, int x1, int y1, int x2, int y2) // Perform a single swap with previously validated coordinates
    {
        string temp = matrix[x1, y1];
        matrix[x1, y1] = matrix[x2, y2];
        matrix[x2, y2] = temp;
    }
    static void PrintMatrix(string[,] matrix) // Print the matrix
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}