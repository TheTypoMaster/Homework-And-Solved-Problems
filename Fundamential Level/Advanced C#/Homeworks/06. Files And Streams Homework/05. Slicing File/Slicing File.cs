using System;
using System.IO;

class SlicingFile
{
    static string[] filePartsNames;
    static string sourceFile = "../../Tiger.jpg";
    static string destinationDirectory = "../../";

    static void Main()
    {
        // Copy a file in the projects root folder to the same folder
        Console.Write("Number of parts: ");
        int parts = int.Parse(Console.ReadLine());
        //sourceFile = Console.ReadLine();
        //destinationDirectory = Console.ReadLine();

        filePartsNames = new string[parts];
        GenerateFilePartsNames(filePartsNames, sourceFile, destinationDirectory);

        SplitFile(sourceFile, destinationDirectory, parts);
        Assemble(filePartsNames, destinationDirectory);
    }

    static void SplitFile(string sourceFile, string destinationDirectory, int parts)
    {
        using (var source = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        {
            for (int i = 0; i < parts; i++)
            {
                using (var copy = new FileStream(filePartsNames[i], FileMode.Create))
                {
                    int position = 0;
                    byte[] buffer = new byte[4096];

                    while (position < source.Length / parts)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        position += readBytes;
                        copy.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }

    static void Assemble(string[] files, string destinationDirectory)
    {
        using (var assemly = new FileStream(destinationDirectory + GetFileName() + "-Assembled" + GetExtention(), FileMode.Create))
        {
            for (int i = 0; i < files.Length; i++)
            {
                using (var source = new FileStream(filePartsNames[i], FileMode.Open))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        assemly.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }

    static void GenerateFilePartsNames(string[] parts, string sourceFile, string destinationDirectory)
    {
        for (int i = 0; i < parts.Length; i++)
        {
            string partName = destinationDirectory + GetFileName() + "-Part-" + i + GetExtention();
            parts[i] = partName;
        }
    }
    static string GetFileName()
    {
        return sourceFile.Substring(sourceFile.LastIndexOf('/') + 1, sourceFile.LastIndexOf('.') - sourceFile.LastIndexOf('/') - 1);
    }
    static string GetExtention()
    {
        return sourceFile.Substring(sourceFile.LastIndexOf('.'), sourceFile.Length - sourceFile.LastIndexOf('.'));
    }
}
