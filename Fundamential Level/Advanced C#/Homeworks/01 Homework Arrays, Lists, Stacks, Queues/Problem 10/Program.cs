using System;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); //Read input 
        int[] numbers = new int[n];
        bool atleastOneMatch = false;

        for (int i = 0; i < n; i++) //Get numbers in an array
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        for (int a = 0; a < numbers.Length; a++) //Check if there are a, b and c such that a2 + b2 = c2
        {
            for (int b = 0; b < numbers.Length; b++)
            {
                for (int c = 0; c < numbers.Length; c++)
                {
                    if (numbers[a] <= numbers[b])
                    {
                        if (Math.Pow(numbers[a], 2) + Math.Pow(numbers[b], 2) == Math.Pow(numbers[c], 2))
                        {
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", numbers[a], numbers[b], numbers[c]);
                            atleastOneMatch = true;
                        }
                    }
                }
            }
        }

        if (!atleastOneMatch)
        {
            Console.WriteLine("No");
        }
    }
}
