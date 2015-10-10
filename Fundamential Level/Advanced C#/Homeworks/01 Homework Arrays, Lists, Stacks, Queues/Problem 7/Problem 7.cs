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
            int desiredSum = 11;
            int[] numbers = "0 11 1 10 5 6 3 4 7 2".Split(' ').Select(int.Parse).Distinct().ToArray(); //read numbers sequence from the console
            List<List<int>> allCombinations = new List<List<int>>(); //list for storing all combinations in list form
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
                combination.Sort(); //sort combination in ascending order

                if (combination.Sum() == desiredSum && combination.Count != 0) //print combination if it equals desired sum
                {
                    allCombinations.Add(combination);
                    isMatchingSubset = true;
                }
            }

            //sort the collection using LINQ in ascending order by count and first element ;
            var sortedCombinations =
                from comb in allCombinations
                orderby comb[0] ascending
                orderby comb.Count ascending
                select comb;

            if (!isMatchingSubset) //Print the results
            {
                Console.WriteLine("No matching subsets.");
            }
            else
            {
                foreach (var item in sortedCombinations)
                {
                    Console.WriteLine("{0} = {1}", string.Join(" + ", item), desiredSum);
                }
            }
        }
    }
}
