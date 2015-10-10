using System;

class CombinationsWithoutRepetition
{
    static int n;
    static int k;
    static int recursionDepth = 0;
    static int index = 0;
    static int[] combination;

    static void Main(string[] args)
    {
        Console.WriteLine("n = 3");
        n = int.Parse("3");

        Console.WriteLine("k = 2");
        k = int.Parse("2");

        combination = new int[k];
        GenerateCombinationsWithoutRepetition(recursionDepth, index);
    }

    static void GenerateCombinationsWithoutRepetition(int recursionDepth, int index)
    {
        if (recursionDepth == k)
        {
            Console.WriteLine(string.Join(", ", combination));
        }
        else
        {
            for (int i = 1 + index; i <= n; i++)
            {
                combination[recursionDepth] = i;
                GenerateCombinationsWithoutRepetition(recursionDepth + 1, index + 1);
                index++;
            }
        }
    }
}
