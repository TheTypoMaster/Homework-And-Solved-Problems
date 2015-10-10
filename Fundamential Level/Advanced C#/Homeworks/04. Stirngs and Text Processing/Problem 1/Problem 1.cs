using System;

class Program
{
    static void Main(string[] args)
    {
        // Reverse a string
        string sample = "sample";
        char[] reversedSample = new char[sample.Length];

        for (int i = 0; i < sample.Length; i++)
        {
            reversedSample[i] = sample[sample.Length - i - 1];
        }

        string output = new string(reversedSample);
        Console.WriteLine(output);
    }
}