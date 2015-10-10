using System;

class CombinationsWithReps // Combinations - Order Does Not Matter
{
    static void Main()
    {
        int n = 3;
        int k = 2;
        int[] combination = new int[k];
        GenCombWithReps(combination, n, 0, 1);
    }

    static void GenCombWithReps(int[] combination, int setSize, int index, int start)
    {
        if (index >= combination.Length)
        {
            Console.WriteLine(string.Join(", ", combination));
        }
        else
        {
            for (int i = start; i <= setSize; i++)
            {
                combination[index] = i;
                GenCombWithReps(combination, setSize, index + 1, i);
            }
        }
    }
}