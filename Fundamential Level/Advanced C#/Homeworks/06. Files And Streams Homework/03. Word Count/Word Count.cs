using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class WordCount
{
    static void Main()
    {
        // Record in a file (results.txt) every occurrence of each word from a file (words.txt) in another file (text.txt)
        string wordsFilePath = "../../words.txt";
        string textFilePath = "../../text.txt";
        string resultsFilePath = "../../results.txt";
        Dictionary<string, int> wordCount = new Dictionary<string, int>(); // Using a dictionary to store word count
        WordCounter(wordsFilePath, textFilePath, wordCount); // Count each occurrence of the words from words.txt in text.txt
        RecordResultsInFile(resultsFilePath, wordCount); // Record results in results.txt
    }

    private static void RecordResultsInFile(string resultsFilePath, Dictionary<string, int> wordCount)
    {
        var items = from pair in wordCount
                    orderby pair.Value descending
                    select pair;

        using (var writer = new StreamWriter(resultsFilePath))
        {
            foreach (KeyValuePair<string, int> pair in items)
            {
                string line = pair.Key + " - " + pair.Value;
                writer.WriteLine(line);
            }
        }
    }
    private static void WordCounter(string wordsFilePath, string textFilePath, Dictionary<string, int> wordCount)
    {
        string pattern = @"[\w]+"; // pattern for a single word
        using (var readerWords = new StreamReader(wordsFilePath))
        {
            string wordLine = readerWords.ReadLine();
            while (wordLine != null)
            {
                Match word = Regex.Match(wordLine, pattern); // This should work for matching multiple words on a single line
                while (word.Success)
                {
                    using (var readerText = new StreamReader(textFilePath))
                    {
                        string textLine = readerText.ReadLine();
                        string wordPattern = @"(?<!\w)" + word.ToString().ToLower() + @"(?!\w)"; // Create pattern for the searched word
                        int count = 0;
                        while (textLine != null) // Search through a line of text.txt
                        {
                            count += Regex.Matches(textLine.ToLower(), wordPattern).Count;
                            textLine = readerText.ReadLine();
                        }
                        if (!wordCount.ContainsKey(word.ToString().ToLower())) // Check if the searched word is already in our dictionary
                        {
                            wordCount.Add(word.ToString().ToLower(), count);
                        }
                        else
                        {
                            wordCount[word.ToString().ToLower()] += count;
                        }
                        word = word.NextMatch(); // This should work for matching multiple words on a single line
                    }
                }
                wordLine = readerWords.ReadLine();
            }
        }
    }
}