using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        numbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray(); //Read input from the console (using .Trim() for whitespaces!!)
        bool atLeastOneStuckNumber = false;

        for (int a = 0; a < numbers.Length; a++) //4 nested for loops combining every possible a,b,c and d
        {
            for (int b = 0; b < numbers.Length; b++)
            {
                for (int c = 0; c < numbers.Length; c++)
                {
                    for (int d = 0; d < numbers.Length; d++)
                    {
                        if (DistinctNumbers(numbers[a], numbers[b], numbers[c], numbers[d])) //Check if a, b, c and d are distinct from each other 
                        {
                            if (AppendTwoNumbers(numbers[a], numbers[b]) == AppendTwoNumbers(numbers[c], numbers[d])) //Method for concatenating ints. Then check if a|b == c|d 
                            {
                                Console.WriteLine("{0}|{1}=={2}|{3}", numbers[a], numbers[b], numbers[c], numbers[d]); //cw if a|b == c|d
                                atLeastOneStuckNumber = true;
                            }
                        }
                    }
                }
            }
        }
        if (!atLeastOneStuckNumber)
        {
            Console.WriteLine("No");
        }
    }

    static int AppendTwoNumbers (int a, int b)
    {
        int temp = b;
        int multiplier = 1;

        while (temp != 0)
        {
            temp /= 10;
            multiplier *= 10;
        }

        a *= multiplier;
        a += b;

        return a;
    }
    static bool DistinctNumbers (int a, int b, int c, int d)
    {
        bool distinctNumbers = true;

        if (a == b || a == c || a == d)
        {
            distinctNumbers = false;
        }
        if (b == c || b == d)
        {
            distinctNumbers = false;
        }
        if (c == d)
        {
            distinctNumbers = false;
        }
        return distinctNumbers;
    }
}
