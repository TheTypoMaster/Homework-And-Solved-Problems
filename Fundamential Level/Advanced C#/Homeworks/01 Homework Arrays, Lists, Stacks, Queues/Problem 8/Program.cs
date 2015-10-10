using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<List<int>> jaggedList = new List<List<int>>(n); //initialize a jagged collection for storing the lego blocks (incl. reversing the second input)
            ReadBlocks(jaggedList, n); //read blocks from the console

            int rowLength = jaggedList[0].Count;
            int totalCells = 0;
            bool legoBlocksFit = true;

            for (int i = 0; i < jaggedList.Count; i++) //check if the blocks fit (by checking row lengths)
            {
                totalCells += jaggedList[i].Count;
                if (jaggedList[i].Count != rowLength)
                {
                    legoBlocksFit = false;
                }
            }
            PrintResult(jaggedList, totalCells, legoBlocksFit); //print the result
        }

        static void ReadBlocks(List<List<int>> jaggedList, int n)
        {
            for (int i = 0; i < n; i++)
            {
                jaggedList.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
            }
            for (int i = 0; i < n; i++)
            {
                jaggedList[i].AddRange(Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToList());
            }
        }
        static void PrintResult(List<List<int>> jaggedList, int totalCells, bool legoBlocksFit)
        {
            if (legoBlocksFit)
            {
                foreach (var item in jaggedList)
                {
                    Console.WriteLine("[{0}]", string.Join(", ", item));
                }
            }
            else
            {
                Console.WriteLine("The total number of cells is: {0}", totalCells);
            }
        }
    }
}
