using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        string[] strings = { "zbc", "Abc", "abc", "acd", "gfc" };
        DateTime[] dates = { new DateTime(2002, 3, 1), new DateTime(2015, 5, 6), new DateTime(2014, 1, 1) };

        GenericSortArray(numbers);
        GenericSortArray(strings);
        GenericSortArray(dates);

        Console.WriteLine(string.Join(" ", numbers));
        Console.WriteLine(string.Join(" ", strings));
        Console.WriteLine(string.Join(" ", dates));
    }

    //Generic method for sorting all sorts of arrays
    static void GenericSortArray<T>(T[] list) where T : IComparable<T>
    {
        bool swapMade = true;
        int lastElementToBeSorted = list.Length - 1;

        while (swapMade)
        {
            swapMade = false;
            for (int i = 1; i <= lastElementToBeSorted; i++)
            {
                if (list[i].CompareTo(list[i - 1]) < 0)
                {
                    T temp = list[i];
                    list[i] = list[i - 1];
                    list[i - 1] = temp;
                    swapMade = true;
                }
            }
            lastElementToBeSorted--;
        }
    }
}
