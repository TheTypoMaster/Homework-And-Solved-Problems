using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] numbers = {1.2f, -4f, 5.00f, 12211f, 93.003f, 4f, 2.2f};
            List<float> realNumbers = new List<float>();
            List<int> integerNumbers = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] - (int)numbers[i] != 0)
                {
                    realNumbers.Add(numbers[i]);
                }
                else if (numbers[i] - (int)numbers[i] == 0)
                {
                    integerNumbers.Add((int)(numbers[i]));
                }
            }

            Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", string.Join(", ", realNumbers), realNumbers.Min(), realNumbers.Max(), realNumbers.Sum(), realNumbers.Average());
            Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", string.Join(", ", integerNumbers), integerNumbers.Min(), integerNumbers.Max(), integerNumbers.Sum(), integerNumbers.Average());
        }
    }
}
