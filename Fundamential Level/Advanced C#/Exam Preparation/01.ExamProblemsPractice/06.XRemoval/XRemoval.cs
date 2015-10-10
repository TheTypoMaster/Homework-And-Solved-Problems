using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        List<string> lines = new List<string>();
        List<StringBuilder> builded = new List<StringBuilder>();

        string command = Console.ReadLine();

        while (command != "END")
        {
            lines.Add(command.ToLower());
            StringBuilder sb = new StringBuilder().Append(command);
            builded.Add(sb);
            command = Console.ReadLine();
        }

        for (int i = 0; i < lines.Count - 2; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (j + 2 < lines[i].Length && j + 1 < lines[i + 1].Length && j + 2 < lines[i + 2].Length)
                {
                    char ch1 = lines[i][j];
                    char ch2 = lines[i][j+2];
                    char ch3 = lines[i+1][j+1];
                    char ch4 = lines[i+2][j];
                    char ch5 = lines[i+2][j+2];
                    if (ch1 == ch2 && ch1 == ch3 && ch1 == ch4 && ch1 == ch5)
                    {
                        builded[i][j] = ' ';
                        builded[i][j + 2] = ' ';
                        builded[i + 1][j + 1] = ' ';
                        builded[i + 2][j] = ' ';
                        builded[i + 2][j + 2] = ' ';
                    }
                }
            }
        }

        foreach (var item in builded)
        {
            item.Replace(" ", "");
            Console.WriteLine(item.ToString());
        }
    }
}
