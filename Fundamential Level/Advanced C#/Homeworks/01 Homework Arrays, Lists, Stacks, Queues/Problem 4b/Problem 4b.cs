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
            List<string> temp = new List<string>();

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
                    temp.Add(input[j]);
                }

                Console.WriteLine(string.Join(" ", temp));
                temp.Clear();
                i += index;
            }

            Console.WriteLine(DateTime.Now - start);
        }
    }
}
