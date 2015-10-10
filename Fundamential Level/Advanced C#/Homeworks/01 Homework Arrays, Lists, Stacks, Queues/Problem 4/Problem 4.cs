using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            DateTime start = DateTime.Now;
            for (int i = 0; i < input.Length; i++)
            {
                int index = 0;

                while (i + index + 1 < input.Length && input[i + index + 1] == input[i])
                {
                    index++;
                }

                for (int j = i; j < i + index + 1; j++)
                {
                    Console.Write(input[j]);
                    if (j != i + index)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
                i += index;
            }

            Console.WriteLine(DateTime.Now - start);
        }
    }
}
