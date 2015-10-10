using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static string map = Console.ReadLine();

    static void Main(string[] args)
    {
        // Terrorist win -> set off bombs in a string such that the blast radius replaces characters with '.'
        StringBuilder destroyedMap = new StringBuilder();
        StringBuilder temp = new StringBuilder();

        // Make a copy of the map
        destroyedMap.Append(map);
        int bombStartIndex = 0;
        int bombEndIndex = 0;
        int bombBlastRadius = 0;

        for (int i = 0; i < map.Length; i++) // Search for bombs
        {
            if (map[i] == '|') // Found start of a bomb
            {
                bombStartIndex = i; // Get start index
                bombEndIndex = GetBombEndIndex(bombStartIndex); // Get end index
                bombBlastRadius = GetBombBlastRadius(bombStartIndex, bombEndIndex); // Calculate blast radius from characters ASCII codes
                i = bombEndIndex; // Continue the loop after the end index of the bomb

                temp.Clear(); 
                temp.Append(SetOffBomb(bombStartIndex, bombEndIndex, bombBlastRadius, destroyedMap.ToString())); // Get the layout of the map after the explosion
                destroyedMap.Clear();
                destroyedMap.Append(temp);
            }
        }
        Console.WriteLine(destroyedMap.ToString());
    }

    static int GetBombEndIndex (int bombStartIndex)
    {
        int counter = 0;
        int bombEndIndex = 0;

        while (map[bombStartIndex + counter + 1] != '|')
        {
            counter++;
        }
        bombEndIndex = bombStartIndex + counter + 1;
        return bombEndIndex;
    }
    static int GetBombBlastRadius (int start, int end)
    {
        int sum = 0;
        for (int i = start + 1; i < end; i++)
        {
            sum += map[i];
        }
        return sum % 10;
    }
    static string SetOffBomb (int start, int end, int radius, string map)
    {
        StringBuilder destroyedMap = new StringBuilder();
        StringBuilder blastedArea = new StringBuilder();

        int blastAreaStart = start - radius;
        int blastAreaEnd = end + radius;

        for (int i = 0; i < map.Length; i++)
        {
            if (i >= start - radius && i <= end + radius)
            {
                destroyedMap.Append('.');
            }
            else
            {
                destroyedMap.Append(map[i]);
            }
        }
        return destroyedMap.ToString();

    }
}
