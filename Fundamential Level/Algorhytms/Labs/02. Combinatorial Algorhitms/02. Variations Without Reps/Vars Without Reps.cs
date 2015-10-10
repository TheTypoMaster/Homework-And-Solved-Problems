using System;
class VariationsWithoutReps // Variations - Order Does Matter
{
    static void Main()
    {
        int n = 3;
        int k = 2;

        bool[] used = new bool[n + 1];
        int[] combination = new int[k];

        GenVarsWithoutReps(n, combination, used, 0);
    }

    static void GenVarsWithoutReps(int setSize, int[] combination, bool[] used, int index)
    {
        if (index >= combination.Length)
        {
            Console.WriteLine(string.Join(" ", combination));
        }
        else
        {
            for (int i = 1; i <= setSize; i++)
            {
                if (!used[i])
                {
                    combination[index] = i;
                    used[i] = true;
                    GenVarsWithoutReps(setSize, combination, used, index + 1);
                    used[i] = false;
                }
            }
        }
    }
}