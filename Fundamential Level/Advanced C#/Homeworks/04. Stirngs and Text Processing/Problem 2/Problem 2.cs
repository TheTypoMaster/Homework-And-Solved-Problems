using System;

class Program
{
    static void Main(string[] args)
    {
        // Read a string which should be less than 20 chars and fill it with "*"s to 20
        string input = new string('a', 20);
        string output = "";

        if (input.Length > 20)
        {
            output = input.Substring(0, 20);
        }
        else
        {
            output = input + new string('*', 20 - input.Length);
        }
        
        Console.WriteLine(input);
        Console.WriteLine(output);
    }
}
