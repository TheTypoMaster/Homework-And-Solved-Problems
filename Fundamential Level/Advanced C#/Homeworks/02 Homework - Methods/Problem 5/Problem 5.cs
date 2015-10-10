using System;

class Program
{
    static void Main(string[] args)
    {
        decimal number = 1.2m;
        double decimalPoints = GetDecimalPoints(number);
        decimal reversedNumber = ReverseNumber(number)/(decimal)Math.Pow(10d, decimalPoints);
        Console.WriteLine(reversedNumber);
    }

    static decimal ReverseNumber(decimal number)
    {
        decimal reversed = 0m;
        while (number - (int)number != 0)
        {
            number *= 10;
        }

        while (number > 0)
        {
            if (reversed != 0)
            {
                reversed *= 10;
            }
            reversed += number % 10;
            number = (int)number / 10;
        }

        return reversed;
    }
    static int GetDecimalPoints (decimal number)
    {
        int decimalPoints = 0;
        int temp = (int)number;
        while (temp > 0)
        {
            temp /= 10;
            decimalPoints++;
        }
        return decimalPoints;
    }
}
