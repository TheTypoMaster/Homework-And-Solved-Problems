using System;

class Program
{
    static void Main(string[] args)
    {
        // Write a program that converts a string to a sequence of C# Unicode character literals. 
        
        string str = "What?!?";

        foreach (char character in str)
        {
            Console.Write("\\u" + Convert.ToString((int)character, 16).PadLeft(4, '0'));
        }
        Console.WriteLine();
    }
}