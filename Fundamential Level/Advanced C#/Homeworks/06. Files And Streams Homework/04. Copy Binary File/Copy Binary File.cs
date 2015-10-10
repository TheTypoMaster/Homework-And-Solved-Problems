using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Copy a file in the projects root folder to the same folder
        string sourcePath = "../../matrix.jpg";
        string copyPath = "../../matrix-copy.jpg";

        using (var source = new FileStream(sourcePath, FileMode.Open))
        {
            using (var copy = new FileStream(copyPath, FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    copy.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
