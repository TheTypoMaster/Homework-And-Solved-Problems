using System;
using System.IO;
using System.IO.Compression;

class ZippingSlicedFiles
{
    static string[] filePartsNames;
    static string sourceFile = "../../Tiger.jpg";
    static string destinationDirectory = "../../";

    static void Main()
    {
        //Console.Write("Number of parts: ");
        int parts = 5;
        //sourceFile = Console.ReadLine();
        //destinationDirectory = Console.ReadLine();

        filePartsNames = new string[parts];
        GenerateFilePartsNames(filePartsNames, sourceFile, destinationDirectory);


        // TODO: Compress
        SplitFile(sourceFile, destinationDirectory, parts);
        Assemble(filePartsNames, destinationDirectory);
        // TODO: Decompress
    }

    static void SplitFile(string sourceFile, string destinationDirectory, int parts)
    {
        byte[] buffer = new byte[4096];

        using (Stream source = File.OpenRead(sourceFile))
        {
            int i = 0;
            while (source.Position < source.Length)
            {
                using (var copy = File.Create(filePartsNames[i] + ".gz"))
                {
                    using (var gz = new GZipStream(copy, CompressionMode.Compress))
                    {
                        int position = 0;

                        while (position < source.Length / parts)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }
                            position += readBytes;
                            gz.Write(buffer, 0, readBytes);
                        }
                    }
                }
                i++;
            }
        }
    }
    static void Assemble(string[] files, string destinationDirectory)
    {
        using (var assemly = new FileStream(destinationDirectory + GetFileName() + "-Assembled" + GetExtention(), FileMode.Create))
        {
            for (int i = 0; i < files.Length; i++)
            {
                using (var source = new FileStream(filePartsNames[i] + ".gz", FileMode.Open))
                {
                    using (var gz = new GZipStream(source, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[4096];

                        while (true)
                        {
                            int readBytes = gz.Read(buffer, 0, buffer.Length);
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
    }
    static void GenerateFilePartsNames(string[] parts, string sourceFile, string destinationDirectory)
    {
        for (int i = 0; i < parts.Length; i++)
        {
            string partName = destinationDirectory + GetFileName() + "-Part-" + i;
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
