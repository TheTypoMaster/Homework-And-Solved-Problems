using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;


class Program
{
    static void Main()
    {
        string pattern = @"(?<=[\d]|\s|\b)([A-Z]{1,})(?=[\d]|\s|\b)";
        string text = Console.ReadLine();

        while (text != "END")
        {
            StringBuilder result = new StringBuilder().Append(text);
            Match match = Regex.Match(result.ToString(), pattern);

            int offset = 0; // offset the index when we double a word
            while (match.Success)
            {
                string word = match.Groups[1].Value;
                string reversed = ReverseWord(word);
                int indexStart = match.Index + offset;
                int indexLength = match.Length;

                if (reversed.Equals(word))
                {
                    string doubled = DoubleCharsInWord(reversed);
                    result.Remove(indexStart, indexLength);
                    result.Insert(indexStart, doubled);
                    offset += indexLength;
                }
                else
                {
                    result.Remove(indexStart, indexLength);
                    result.Insert(indexStart, reversed);
                }
                match = match.NextMatch();
            }
            Console.WriteLine(SecurityElement.Escape(result.ToString()));
            text = Console.ReadLine();
        }
    }

    private static string DoubleCharsInWord(string word)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < word.Length; i++)
        {
            builder.Append(word[i]);
            builder.Append(word[i]);
        }
        return builder.ToString();
    }

    private static string ReverseWord(string word)
    {
        StringBuilder builer = new StringBuilder();
        for (int i = 0; i < word.Length; i++)
        {
            builer.Insert(0, word[i]);
        }
        return builer.ToString();
    }
}
