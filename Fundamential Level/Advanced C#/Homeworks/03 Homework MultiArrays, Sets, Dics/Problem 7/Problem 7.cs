using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a phonebook with names and numbers and a search functionality to it
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        string[] input = new string[2];

        // Read phonebook from the console until "search" command is initiated
        string command = Console.ReadLine();
        while (command != "search")
        {
            input = command.Trim().Split('-');
            phoneBook.Add(input[0], input[1]);
            command = Console.ReadLine();
        }

        // Search the phonebook until "end" command is initiated
        command = Console.ReadLine();
        while (command != "end")
        {
            if (phoneBook.ContainsKey(command))
            {
                Console.WriteLine("{0} -> {1}", command, phoneBook[command]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", command);
            }
            command = Console.ReadLine();
        }
    }
}
