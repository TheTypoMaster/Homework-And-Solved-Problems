using System;
using System.Linq;

class PermutationsWithIteration
{
    static void Main(string[] args)
    {
        int n = 3;
        int[] array = Enumerable.Range(1, n).ToArray();
        int[] perm = Enumerable.Range(0, n + 1).ToArray();
        int index = 1;
        int j = 0;

        while (index < n)
        {
            Console.WriteLine(string.Join(", ", array));
            perm[index]--;
            j = index % 2 != 0 ? perm[index] : 0;
            Swap(array, index, j);
            index = 1;
            while (perm[index] == 0)
            {
                perm[index] = index;
                index++;
            }
        }
        Console.WriteLine(string.Join(", ", array));
    }

    static void Swap (int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
