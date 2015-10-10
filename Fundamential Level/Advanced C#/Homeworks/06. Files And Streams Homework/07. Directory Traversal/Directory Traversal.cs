using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class DirectoryTraversal
{
    static void Main()
    {
        Console.Write("Path to directory to traverse files: ");
        string dirPath = Console.ReadLine();
        string[] files = Directory.GetFiles(dirPath);
        FileInfo[] fileInfo = Directory.GetFiles(dirPath).Select(x => new FileInfo(x)).ToArray();
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        var grouped = fileInfo
            .OrderBy(file => file.Length)
            .GroupBy(file => file.Extension)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key);

        using (StreamWriter writer = new StreamWriter(desktopPath + "\\Report.txt"))
        {
            foreach (var group in grouped)
            {
                writer.WriteLine(group.Key);
                foreach (var item in group)
                {
                    writer.WriteLine("--{0} - {1}kb", item.Name, item.Length / 1000);
                }
            }
        }
        Console.WriteLine("Report.txt exported to desktop");
    }
}
