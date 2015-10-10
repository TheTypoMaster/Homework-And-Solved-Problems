using System;

class CombinationsWithoutRepetition
{
    static void Main()
    {
        int n = 5;
        int k = 3;
        int[] combination = new int[k];
        GenCombsWitoutReps(combination, n, 0);
    }

    static void GenCombsWitoutReps(int[] combinations, int setSize, int index, int start = 1)
    {
        if (index >= combinations.Length)
        {
            Console.WriteLine(string.Join(", ", combinations));
        }
        else
        {
            for (int i = start; i <= setSize; i++)
            {
                combinations[index] = i;
                GenCombsWitoutReps(combinations, setSize, index + 1, i + 1);
            }
        }
    }
}