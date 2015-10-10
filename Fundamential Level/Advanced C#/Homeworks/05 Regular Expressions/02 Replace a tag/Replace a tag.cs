using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Replace all tags that contain url addresses with the specified pattern
        string pattern = @"(<a href=(.+)>)(.+)(<\/a>)";
        Regex regex = new Regex(pattern);

        string text = Console.ReadLine();

        //string text = "<ul>" +
        //                "\n<li>" +
        //                  "\n<a href=http://softuni.bg>SoftUni</a>" +
        //                 "\n</li>" +
        //                "\n</ul>";

        Console.WriteLine(text + "\n");

        string result = regex.Replace(text, @"[URL href=$2]$3[/URL]");
        Console.WriteLine(result);
    }
}
