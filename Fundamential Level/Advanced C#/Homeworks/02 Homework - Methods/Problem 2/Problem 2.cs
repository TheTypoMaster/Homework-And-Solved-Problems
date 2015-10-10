using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetLastDigitAsWord(745));
        }

        static string GetLastDigitAsWord (int number)
        {
            switch (number % 10)
            {
                case 0: return "zero"; break;
                case 1: return "one"; break;
                case 2: return "two"; break;
                case 3: return "three"; break;
                case 4: return "four"; break;
                case 5: return "five"; break;
                case 6: return "six"; break;
                case 7: return "seven"; break;
                case 8: return "eigth"; break;
                case 9: return "nine"; break;
                default: break;
            }
            return "No";
        }
    }
}
