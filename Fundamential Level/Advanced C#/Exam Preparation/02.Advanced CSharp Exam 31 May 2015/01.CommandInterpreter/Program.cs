using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] array = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
        string command = Console.ReadLine();
        string pattern = @"(?:reverse from|sort from|rollLeft|rollRight)\s*[0-9]+\s*(?:count\s*[0-9]+|)";

        while (command.ToLower() != "end")
        {
            Match match = Regex.Match(command.Trim(), pattern);
            if (match.Success)
            {
                string[] commandArgs = command.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "reverse")
                {
                    long start = long.Parse(commandArgs[2]);
                    long count = long.Parse(commandArgs[4]);

                    if (start < array.Length && start >= 0 && start + count <= array.Length && count >=0)
                    {
                        Reverse(array, start, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (commandArgs[0] == "sort")
                {
                    long start = long.Parse(commandArgs[2]);
                    long count = long.Parse(commandArgs[4]);

                    if (start < array.Length && start >= 0 && start + count <= array.Length && count >= 0)
                    {
                        Sort(array, start, count); ;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (commandArgs[0] == "rollLeft")
                {
                    if (long.Parse(commandArgs[1]) >= 0)
                    {
                        array = RollLeft(array, commandArgs);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (commandArgs[0] == "rollRight")
                {
                    if (long.Parse(commandArgs[1]) >= 0)
                    {
                        array = RollRight(array, commandArgs);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input parameters.");
            }
            
            command = Console.ReadLine();
        }
        Console.WriteLine("[{0}]", string.Join(", ", array));
    }

    private static void Sort(string[] array, long start, long count)
    {
        for (long i = start; i < start + count - 1; i++)
        {
            long minIndex = i;
            for (long j = i + 1; j < start + count; j++)
            {
                if (array[j].CompareTo(array[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }
            string temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
    }

    private static void Reverse(string[] array, long start, long count)
    {

        long index = 1;
        for (long i = start; i < start + count / 2; i++)
        {
            string temp = array[i];
            array[i] = array[start + count - index];
            array[start + count - index] = temp;
            index++;
        }
    }

    private static string[] RollRight(string[] array, string[] commandArgs)
    {
        long count = long.Parse(commandArgs[1]) % array.Length;

        Array.Reverse(array);
        Queue<string> temp = new Queue<string>(array);

        while (count > 0)
        {
            string firstElement = temp.First();
            temp.Dequeue();
            temp.Enqueue(firstElement);
            count--;
        }

        array = temp.ToArray();
        Array.Reverse(array);
        return array;
    }

    private static string[] RollLeft(string[] array, string[] commandArgs)
    {
        long count = long.Parse(commandArgs[1]) % array.Length;
  
        Queue<string> temp = new Queue<string>(array);

        while (count > 0)
        {
            string firstElement = temp.First();
            temp.Dequeue();
            temp.Enqueue(firstElement);
            count--;
        }

        return temp.ToArray();
    }
}
