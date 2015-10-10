using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Censor all occurances of given words in a text with '*'s with the same length

        string[] banlist = "Linux, Windows".Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
        string text = "It is not Linux, it is GNU/Linux. Linux is merely the kernel, while GNU adds the functionality. Therefore we owe it to them by calling the OS GNU/Linux! Sincerely, a Windows client";

        StringBuilder result = new StringBuilder(text);

        foreach (string bannedWord in banlist)
        {
            result.Replace(bannedWord, new string('*', bannedWord.Length));
        }

        Console.WriteLine(result.ToString());
    }
}