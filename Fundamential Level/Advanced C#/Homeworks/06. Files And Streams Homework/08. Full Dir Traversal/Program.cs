using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static List<FileInfo> fileInfo = new List<FileInfo>(); // Global list to store all files found
    static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Get the path to user's desktop
    
    static void Main()
    {
        string initialDir = Console.ReadLine(); // Starting directory for the traversal
        Traverse(initialDir); // Recursively get all files in the directory and sub directories

        var grouped = fileInfo // Group files by extensions / TODO: Need to figure out why the .ThenBy() is not working
            .OrderBy(x => x.Length)
            .GroupBy(x => x.Extension)
            .Select(x => new { Key = x.Key, Files = x })
            .OrderByDescending(x => x.Key.Count())
            .ThenBy(x => x.Key);

        using (StreamWriter writer = new StreamWriter(desktopPath + "\\Report.txt")) // Write results in a file named Report.txt
        {
            foreach (var group in grouped)
            {
                writer.WriteLine(group.Key);
                foreach (var item in group.Files)
                {
                    writer.WriteLine("--{0} - {1}kb", item.Name, item.Length / 1000);
                }
            }
        }
        Console.WriteLine("Report.txt exported to desktop");
    }

    static void Traverse(string currentDir)
    {
        DirectoryInfo info = new DirectoryInfo(currentDir);
        DirectoryInfo[] directories = info.GetDirectories();
        fileInfo.AddRange(Directory.GetFiles(currentDir).Select(x => new FileInfo(x)).ToList());

        if (directories.Length == 0)
        {
            return;
        }
        else
        {
            foreach (var item in directories)
            {
                Traverse(currentDir + "\\" + item.ToString());
            }
        }
    }
}