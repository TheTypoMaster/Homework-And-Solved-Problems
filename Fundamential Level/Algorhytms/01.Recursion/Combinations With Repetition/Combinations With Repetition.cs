using System;

class CombinationsWithRepetition
{
    static int k; // Combination of K elements from a..
    static int n; // Set of N elements
    static int currentLoop = 0;
    static int nextElement = 1;
    static int[] combination;

    static void Main(string[] args)
    {
        Console.Write("k = ");
        k = int.Parse(Console.ReadLine());

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        combination = new int[k];

        GenerateCombinationsWithRepetition(currentLoop, nextElement);
    }

    static void GenerateCombinationsWithRepetition(int currentLoop, int nextElement)
    {
        if (currentLoop == k)
        {
            Console.WriteLine(string.Join(", ", combination));
            return;
        }
        else
        {
            for (int index = nextElement; index <= n; index++)
            {
                combination[currentLoop] = index;
                GenerateCombinationsWithRepetition(currentLoop + 1, nextElement);
                nextElement++;
            }
        }
    }
}
