using System;

class VariationsWithRepetition // Variations - Order Does Matter
{
    static void Main()
    {
        int n = 3;
        int k = 2; 
        int[] combination = new int[k];

        GenVarWithReps(n, k, combination, 0);
    }

    static void GenVarWithReps(int setSize, int combSize, int[] combination, int index)
    {
        if (index >= combSize)
        {
            Console.WriteLine(string.Join(", ", combination));
        }
        else
        {
            for (int i = 1; i <= setSize; i++)
            {
                combination[index] = i;
                GenVarWithReps(setSize, combSize, combination, index + 1);
            }
        }
    }
}