using System;
using System.IO;

class OddLines
{
    static void Main(string[] args)
    {
        string textFilePath = "../../textFile.txt";

        // Create a text file in the directory of the project with 99 numerated lines 
        using (var writer = new StreamWriter(textFilePath))
        {
            string line;
            for (int i = 0; i < 100; i++)
            {
                line = "Line: " + i;
                writer.WriteLine(line);
            }
        }

        // Read and print all the odd lines in the file
        using (var reader = new StreamReader(textFilePath))
        {
            string line = reader.ReadLine();
            int counter = 0;

            while (line != null)
            {
                if (counter % 2 != 0)
                {
                    Console.WriteLine(line);
                }
                line = reader.ReadLine();
                counter++;
            }
        }
    }
}
