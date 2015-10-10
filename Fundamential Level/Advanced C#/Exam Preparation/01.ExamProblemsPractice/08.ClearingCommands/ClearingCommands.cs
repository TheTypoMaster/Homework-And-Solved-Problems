using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security;

class Program
{
    static void Main()
    {
        List<StringBuilder> builder = new List<StringBuilder>();

        string command = Console.ReadLine();

        while (command.Trim() != "END")
        {
            StringBuilder sb = new StringBuilder().Append(command);
            builder.Add(sb);
            command = Console.ReadLine();
        }

        for (int i = 0; i < builder.Count; i++)
        {
            for (int j = 0; j < builder[i].Length; j++)
            {
                if (new char[] { '<', '>', 'v', '^' }.Contains(builder[i][j]))
                {
                    char currentChar = builder[i][j];
                    int currentRow = i;
                    int currentCol = j;

                    SwitchDirection(currentChar, ref currentRow, ref currentCol);

                    while (currentRow < builder.Count && currentRow >= 0 
                        && currentCol < builder[currentRow].Length && currentCol >= 0 
                        && !new char[] { '<', '>', 'v', '^' }.Contains(builder[currentRow][currentCol])) // erase symbols
                    {
                            builder[currentRow][currentCol] = ' ';
                            SwitchDirection(currentChar, ref currentRow, ref currentCol);
                    }
                }
            }
        }

        foreach (var item in builder)
        {
            Console.Write("<p>");
            Console.Write(SecurityElement.Escape(item.ToString()));
            Console.WriteLine("</p>");
        }
    }

    private static void SwitchDirection(char currentChar, ref int currentRow, ref int currentCol)
    {
        switch (currentChar) // switch case direction
        {
            case '>':
                currentCol++; break;
            case '<':
                currentCol--; break;
            case 'v':
                currentRow++; break;
            case '^':
                currentRow--; break;
            default: break;
        }
    }
}
