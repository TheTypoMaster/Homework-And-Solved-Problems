using System;
using System.Collections.Generic;
using System.Linq;

class TowerOfHanoi
{
    // Solve the puzzle Tower of Hanoi with minimum steps
    static int stepsTaken = 0;

    static void Main(string[] args)
    {
        Console.Write("Input how many disk your tower has: ");
        int n = int.Parse(Console.ReadLine());

        Stack<int> source = new Stack<int>(Enumerable.Range(1, n).Reverse());
        Stack<int> spare = new Stack<int>();
        Stack<int> destination = new Stack<int>();

        MoveDisks(n, source, spare, destination);

        Console.WriteLine("Steps taken to complete the task using recursion: {0}", stepsTaken);
    }

    private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> spare, Stack<int> destination)
    {
        stepsTaken++;

        if (bottomDisk == 1)
        {
            destination.Push(source.Pop());
        }
        else
        {
            // Move disks on top of bottomDisk to spare
            MoveDisks(bottomDisk - 1, source, destination, spare);

            // Opearation to move a single disk
            destination.Push(source.Pop());

            // Move disks we previously moved to spare, but now to destination
            MoveDisks(bottomDisk - 1, spare, source, destination);
        }
    }
}
