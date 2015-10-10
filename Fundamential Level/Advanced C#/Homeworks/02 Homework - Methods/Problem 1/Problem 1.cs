using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(GetMax(1, -9));
        }

        static int GetMax(int firstNumber, int secondNumber)
        {
            int max = firstNumber >= secondNumber ? firstNumber : secondNumber;
            return max;
        }
    }
}
