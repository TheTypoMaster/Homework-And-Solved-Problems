using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];
            List<string> sequence = new List<string>();
            List<string> longestSequence = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                int index = 1;
                sequence.Add(input[i]);
                while (i + index < numbers.Length && numbers[i + index] > numbers[i + index - 1])
                {
                    sequence.Add(input[i + index]);
                    index++;
                }

                if (sequence.Count > longestSequence.Count)
                {
                    longestSequence.Clear();
                    longestSequence.AddRange(sequence);
                }

                Console.WriteLine(string.Join(" ", sequence));
                sequence.Clear();
                i += index - 1;
            }

            Console.WriteLine("Longest: {0}", string.Join(" ", longestSequence));
        }
    }
}
