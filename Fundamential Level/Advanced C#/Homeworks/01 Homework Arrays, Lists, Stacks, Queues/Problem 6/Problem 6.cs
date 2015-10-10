using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int desiredSum = 0;
            int[] numbers = "1 2 3 4 5".Split(' ').Select(int.Parse).Distinct().ToArray(); //read numbers sequence from the console
            bool isMatchingSubset = false;

            for (int i = 0; i < Math.Pow(2, numbers.Length); i++) //generate all subsets using a bitwise mask
            {
                List<int> combination = new List<int>();
                for (int j = 0; j < numbers.Length; j++)
                {
                    if ((i & (1 << (numbers.Length - j - 1))) != 0)
                    {
                        combination.Add(numbers[j]);
                    }
                }
                combination.Distinct(); //filter out repeating numbers and especially zeroes

                if (combination.Sum() == desiredSum && combination.Count != 0) //print combination if it equals desired sum
                {
                    Console.WriteLine("{0} = {1}", string.Join(" + ", combination), desiredSum);
                    isMatchingSubset = true;
                }
            }

            if (!isMatchingSubset)
            {
                Console.WriteLine("No matching subsets.");
            }
        }
    }
}
