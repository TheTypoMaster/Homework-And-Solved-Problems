using System;

class Factorial
{
    static void Main(string[] args)
    {
        Console.Write("n [1 - 12] = ");
        int n = int.Parse(Console.ReadLine());
        
        int result = Factorial(n); // = Factorial(n);

        Console.WriteLine("{0}! = {1}", n, result);   
    }

    static int Factorial (int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * Factorial(n - 1);
        }
    }
}
