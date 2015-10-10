using System;
using System.Linq;

class Permutations
{
    static int count = 0;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = Enumerable.Range(1, n).ToArray();
        Permute(array);
        Console.WriteLine("Total permutations: {0}", count);
    }

    static void Permute(int[] array, int startIndex = 0)
    {
        if (startIndex >= array.Length - 1)
        {
            Console.WriteLine(string.Join(", ", array));
            count++;
        }
        else
        {
            for (int i = startIndex; i < array.Length; i++)
            {
                Swap(array, startIndex, i);
                Permute (array, startIndex + 1);
                Swap(array, i, startIndex);
            }
        }
    }

    static void Swap(int[] array, int i, int k)
    {
        int tmp = array[i];
        array[i] = array[k];
        array[k] = tmp;
    }
}
