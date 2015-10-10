using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        double r = int.Parse(Console.ReadLine());
        int center = n / 2; // Calculate the cener row and the center col

        for (int row = 0; row < n; row++) // Check if the point is inside the radius for each quandrant separately
        {
            for (int col = 0; col < n; col++)
            {
                // I Quadrant
                if (row <= (n / 2) && col >= n / 2)
                {
                    if (Math.Pow(((double)col - (double)center), 2) + Math.Pow(((double)center - (double)row), 2) <= Math.Pow(r, 2))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                // II Quadrant
                else if (row >= (n / 2) && col >= (n / 2))
                {
                    if (Math.Pow(((double)col - (double)center), 2) + Math.Pow(((double)row - (double)center), 2) <= Math.Pow(r, 2))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                // III Quadrant
                else if (row >= (n / 2) && col <= (n / 2))
                {
                    if (Math.Pow(((double)center - (double)col), 2) + Math.Pow(((double)row - (double)center), 2) <= Math.Pow(r, 2))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                // IV Quadrant
                else if (row <= (n / 2) && col <= (n / 2))
                {
                    if (Math.Pow(((double)center - (double)col), 2) + Math.Pow(((double)center - (double)row), 2) <= Math.Pow(r, 2))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
            }
            Console.WriteLine();
        }
    }
}

