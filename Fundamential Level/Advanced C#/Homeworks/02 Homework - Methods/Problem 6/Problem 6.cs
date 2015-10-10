using System;

class Program
{
    static void Main(string[] args)
    {
        decimal[] set = { 1, 2, 3, 4, 5 };
        decimal min = GetMin(set);
        decimal max = GetMax(set);
        decimal avg = GetAverage(set);
        decimal sum = GetSum(set);
        decimal product = GetProduct(set);

        Console.WriteLine("set: " + string.Join(" ", set));
        Console.WriteLine("min: " + min);
        Console.WriteLine("max: " + max);
        Console.WriteLine("avg: " + avg);
        Console.WriteLine("sum: " + sum);
        Console.WriteLine("product: " + product);
    }

    //Overloaded method for getting the product of set of numbers
    static int GetProduct (int[] set)
    {
        int product = 1;
        for (int i = 0; i < set.Length; i++)
        {
            product *= set[i];
        }
        return product;
    }
    static double GetProduct(double[] set)
    {
        double product = 1;
        for (int i = 0; i < set.Length; i++)
        {
            product *= set[i];
        }
        return product;
    }
    static decimal GetProduct(decimal[] set)
    {
        decimal product = 1;
        for (int i = 0; i < set.Length; i++)
        {
            product *= set[i];
        }
        return product;
    }

    //Overloaded method for getting the sum of set of numbers
    static int GetSum (int[] set)
    {
        int sum = 0;
        for (int i = 0; i < set.Length; i++)
        {
            sum += set[i];
        }
        return sum;
    }
    static double GetSum(double[] set)
    {
        double sum = 0;
        for (int i = 0; i < set.Length; i++)
        {
            sum += set[i];
        }
        return sum;
    }
    static decimal GetSum(decimal[] set)
    {
        decimal sum = 0;
        for (int i = 0; i < set.Length; i++)
        {
            sum += set[i];
        }
        return sum;
    }

    //Overloaded method for getting the average of set of numbers
    static double GetAverage (int[] set)
    {
        return GetSum(set) / set.Length;
    }
    static double GetAverage(double[] set)
    {
        return GetSum(set) / set.Length;
    }
    static decimal GetAverage(decimal[] set)
    {
        return GetSum(set) / set.Length;
    }

    //Overloaded method for getting the maximum element of set of numbers
    static int GetMax (int[] set)
    {
        int max = Int32.MinValue;
        for (int i = 0; i < set.Length; i++)
        {
            if (set[i] > max)
            {
                max = set[i];
            }
        }
        return max;
    }
    static double GetMax(double[] set)
    {
        double max = Int32.MinValue;
        for (int i = 0; i < set.Length; i++)
        {
            if (set[i] > max)
            {
                max = set[i];
            }
        }
        return max;
    }
    static decimal GetMax(decimal[] set)
    {
        decimal max = Int32.MinValue;
        for (int i = 0; i < set.Length; i++)
        {
            if (set[i] > max)
            {
                max = set[i];
            }
        }
        return max;
    }

    //Overloaded method for getting the minimum element of set of numbers
    static int GetMin (int[] set)
    {
        int min = Int32.MaxValue;
        for (int i = 0; i < set.Length; i++)
        {
            if (set[i] < min)
            {
                min = set[i];
            }
        }
        return min;
    }
    static double GetMin(double[] set)
    {
        double min = Int32.MaxValue;
        for (int i = 0; i < set.Length; i++)
        {
            if (set[i] < min)
            {
                min = set[i];
            }
        }
        return min;
    }
    static decimal GetMin(decimal[] set)
    {
        decimal min = Int32.MaxValue;
        for (int i = 0; i < set.Length; i++)
        {
            if (set[i] < min)
            {
                min = set[i];
            }
        }
        return min;
    }
}
