using System;
using System.Text.RegularExpressions;

class SentanceExtractor
{
    static void Main()
    {
        // Extract all sentances containing the keyword
        string keyword = Console.ReadLine();
        string text = Console.ReadLine();

        string pattern = @"\b.*?(?=\b" + keyword + @"\b).*?[!.?]";
        
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        foreach (Match match in matches)
        {
            Console.WriteLine("\n" + match);
        }
    }
}
