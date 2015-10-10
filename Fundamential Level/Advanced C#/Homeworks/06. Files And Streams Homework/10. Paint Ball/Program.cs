using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] canvas = new int[10] { 1023, 1023, 1023, 1023, 1023, 1023, 1023, 1023, 1023, 1023 }; // Initial canvas
        string command = Console.ReadLine();
        string[] shot = new string[3];
        int row = 0;
        int col = 0;
        int radius = 0;
        int counter = 0;

        while (command.ToLower() != "end")
        {
            shot = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            row = int.Parse(shot[0]);
            col = int.Parse(shot[1]);
            radius = int.Parse(shot[2]);

            for (int i = row - radius; i <= row + radius; i++)
            {
                if (counter % 2 == 0)
                {
                    // Unset a bit
                    for (int index = col - radius; index <= col + radius; index++)
                    {
                        if (index >= 0 && index <= 9 && i >= 0 && i <= 9)
                        {
                            canvas[i] &= ~(1 << index);
                        }
                    }
                }
                else if (counter % 2 == 1)
                {
                    // Set a bit
                    for (int index = col - radius; index <= col + radius; index++)
                    {
                        if (index >= 0 && index <= 9 && i >= 0 && i <= 9)
                        {
                            canvas[i] |= (1 << index);
                        }
                    }
                }
            }
            command = Console.ReadLine();
            counter++;
        }
        Console.WriteLine(canvas.Sum());
    }
}
