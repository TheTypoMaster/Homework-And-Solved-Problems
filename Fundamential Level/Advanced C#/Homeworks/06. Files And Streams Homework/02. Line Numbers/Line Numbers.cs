using System;
using System.IO;

class LineNumbers
{
    static void Main(string[] args)
    {
        string sourceFilePath = "../../source.txt";
        string destinationFilePath = "../../destination.txt";

        // Create a file in the project directory with 100 numerated lines
        using (var writer = new StreamWriter(sourceFilePath))
        {
            for (int i = 0; i < 100; i++)
			{
                string line = "Line: " + i;
                writer.WriteLine(line);
			}
        }

        // Insert line number infront of every line
        using (var reader = new StreamReader(sourceFilePath))
        {
            using (var writer = new StreamWriter(destinationFilePath))
            {
                string line = reader.ReadLine();
                int counter = 0;
                while (line != null)
                {
                    writer.WriteLine("{0}: {1}", counter, line);
                    line = reader.ReadLine();
                    counter++;
                }
            }
        }
    }
}