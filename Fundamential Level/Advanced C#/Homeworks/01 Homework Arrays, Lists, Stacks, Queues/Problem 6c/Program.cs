using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string readLine = Console.ReadLine();
        string[] stringsArray = readLine.Split(' ');

        int[] numbersArray = new int[stringsArray.Length]; //transform string line into an int array
        for (int i = 0; i < stringsArray.Length; i++)
        {
            numbersArray[i] = Int32.Parse(stringsArray[i]);
        }
        List<int[]> list = new List<int[]>();
        for (int i = 0; i < Math.Pow(2, numbersArray.Length); i++)
        {
            int[] combination = new int[numbersArray.Length];
            for (int j = 0; j < numbersArray.Length; j++)
            {
                if ((i & (1 << (numbersArray.Length - j - 1))) != 0)
                {
                    combination[j] = numbersArray[j];
                }
            }
            for (int k = 0; k < list.Count; k++) //check if combination is equal to n
            {
                int sum = 0;
                for (int j = 0; j < list[k].Length; j++)
                {
                    sum = sum + list[k][j];
                }
                if (sum == n)
                {
                    for (int j = 0; j < list[k].Length; j++) //print a result that is equal to n
                    {
                        Console.Write(list[k][j]);
                        if (j != list[k].Length - 1)
                        {
                            Console.Write("+");
                        }
                    }
                    Console.WriteLine("=" + n);
                }
            }
            list.Add(combination);
        }
    }
}