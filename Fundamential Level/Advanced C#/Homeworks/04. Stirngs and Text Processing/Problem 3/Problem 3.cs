using System;

class Program
{
    static void Main(string[] args)
    {
        string line = "ababa caba";

        string substring = "aba";
        int index = 0;

        int counter = 0;

        for (int i = 0; i < line.Length; i++)
        {
            if (line.ToLower().IndexOf(substring, i) != -1)
            {
                index = line.ToLower().IndexOf(substring, i);
                counter++;
                i = index;
            }
            
        }
        Console.WriteLine(counter);
    }
}
