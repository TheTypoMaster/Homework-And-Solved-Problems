using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Read a board of 4 strings with different lengths from the console. Then with a given path find how many coins are collected and how many walls are hit.
        string[] board = new string[4]; //Read board from the console
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = Console.ReadLine();
        }

        //string path = "V>>^^>>>VVV<<";
        string path = Console.ReadLine(); //Read path from the console

        int row = 0;
        int col = 0;
        int coinsCollected = 0;
        int wallsHit = 0;

        for (int i = 0; i < path.Length; i++) //Iterate through the path
        {
            MakeNextMove(board, path[i], ref row, ref col, ref coinsCollected, ref wallsHit);
        }

        Console.WriteLine("Coins collected: {0}", coinsCollected);
        Console.WriteLine("\nWalls hit: {0}", wallsHit); 
    }

    static void MakeNextMove (string[] board, char direction, ref int row, ref int col, ref int coinsCollected, ref int wallsHit)
    {
        //check if there are coins collected, walls hit or coordinate change
        if (direction == 'V')
        {
            row++;
            if ((row > board.Length - 1) || (row < 0) || (col > board[row].Length - 1) || (col < 0))
            {
                wallsHit++;
                row--;
            }
            else if (board[row][col] == '$')
            {
                coinsCollected++;
            }
        }
        else if (direction == '<')
        {
            col--;
            if ((row > board.Length - 1) || (row < 0) || (col > board[row].Length - 1) || (col < 0))
            {
                wallsHit++;
                col++;
            }
            else if (board[row][col] == '$')
            {
                coinsCollected++;
            }
        }
        else if (direction == '^')
        {
            row--;
            if ((row > board.Length - 1) || (row < 0) || (col > board[row].Length - 1) || (col < 0))
            {
                wallsHit++;
                row++;
            }
            else if (board[row][col] == '$')
            {
                coinsCollected++;
            }
        }
        else if (direction == '>')
        {
            col++;
            if ((row > board.Length - 1) || (row < 0) || (col > board[row].Length - 1) || (col < 0))
            {
                wallsHit++;
                col--;
            }
            else if (board[row][col] == '$') 
            {
                coinsCollected++;
            }
        }
    }
}
