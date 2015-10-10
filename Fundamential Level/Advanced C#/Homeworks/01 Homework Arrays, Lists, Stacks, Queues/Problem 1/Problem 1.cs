using System;
using System.Collections.Generic;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            List<int> numbers = new List<int> ();

            
            for (int i = 0; i < input.Length; i++)
            {
                if (!string.IsNullOrEmpty(input[i]))
                {
                    numbers.Add(int.Parse(input[i]));
                }
            }

            SortList(numbers);

            if (numbers.Count != 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                Console.WriteLine("Empty List!");
            }
        }

        static void SortList (List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int min = numbers[i];
                int index = 0;

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] < min)
                    {
                        min = numbers[j];
                        index = j;
                    }
                }

                if (min < numbers[i])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[index];
                    numbers[index] = temp;
                }
            }
        }
    }
}
