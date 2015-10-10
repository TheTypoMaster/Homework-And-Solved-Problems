using System;

class Program
{
    static void Main(string[] args)
    {
        // Get the coordinates of the three star systems
        string[] starSystem1 = Console.ReadLine().Trim().Split(' ');
        string starSystem1Name = starSystem1[0];
        decimal starSystem1X = decimal.Parse(starSystem1[1]);
        decimal starSystem1Y = decimal.Parse(starSystem1[2]);

        string[] starSystem2 = Console.ReadLine().Trim().Split(' ');
        string starSystem2Name = starSystem2[0];
        decimal starSystem2X = decimal.Parse(starSystem2[1]);
        decimal starSystem2Y = decimal.Parse(starSystem2[2]);

        string[] starSystem3 = Console.ReadLine().Trim().Split(' ');
        string starSystem3Name = starSystem3[0];
        decimal starSystem3X = decimal.Parse(starSystem3[1]);
        decimal starSystem3Y = decimal.Parse(starSystem3[2]);

        // Get the coordinates of the Normandy
        string[] normandyCoordinates = Console.ReadLine().Trim().Split(' ');
        decimal normandyX = decimal.Parse(normandyCoordinates[0]);
        decimal normandyY = decimal.Parse(normandyCoordinates[1]);

        int normandyTurnsLeft = int.Parse(Console.ReadLine().Trim());

        for (int i = 0; i <= normandyTurnsLeft; i++) // For each position of Normandy, check if it is inside in any of the solar systems
        {
            if ((normandyX <= starSystem1X + 1 && normandyX >= starSystem1X - 1) &&
                (normandyY <= starSystem1Y + 1 && normandyY >= starSystem1Y + 1))
            {
                Console.WriteLine(starSystem1Name.ToLower());
            }
            else if ((normandyX <= starSystem2X + 1 && normandyX >= starSystem2X - 1) &&
                (normandyY <= starSystem2Y + 1 && normandyY >= starSystem2Y - 1))
            {
                Console.WriteLine(starSystem2Name.ToLower());
            }
            else if ((normandyX <= starSystem3X + 1 && normandyX >= starSystem3X - 1) &&
                (normandyY <= starSystem3Y + 1 && normandyY >= starSystem3Y - 1))
            {
                Console.WriteLine(starSystem3Name.ToLower());
            }
            else
            {
                Console.WriteLine("space");
            }
            normandyY++;
        }
    }
}
