using System;

class NestedLoops
{
    static int n;
    static int index;
    static int[] combination;

    static void Main(string[] args)
    {
        Console.WriteLine("Number of nested loops to simulate");
        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        index = n;
        combination = new int[n];

        RecursiveNestedLoops(0);
    }

    static void RecursiveNestedLoops (int n)
    {
        if (n == index)
        {
            Console.WriteLine(string.Join(" ", combination));
        }
        else
        {
            for (int i = 1; i <= index; i++)
            {
                combination[n] = i;
                RecursiveNestedLoops(n + 1);
            }
        }
    }
}

