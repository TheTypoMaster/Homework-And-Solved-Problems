using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        double sum = 0;
        string pattern = @"(^[a-zA-Z_]+(?=[\d])).*((?<=[\d])[a-zA-Z_]+$)";
        
        string keyString = Console.ReadLine();
        string textString = Console.ReadLine();

        Match match = Regex.Match(keyString, pattern);

        if (match.Success)
        {
            string startKey = match.Groups[1].Value;
            string endKey = match.Groups[2].Value;

            string newPattern = startKey + @"([0-9\.]+)" + endKey;
            MatchCollection newMatch = Regex.Matches(textString, newPattern);
            foreach (Match m in newMatch)
	        {
                string number = m.Groups[1].Value;
                double value = double.Parse(number);
                sum += value;
	        }
        }
        else
        {
            Console.WriteLine("<p>A key is missing</p>");
            return;
        }

        if (sum != 0)
        {
            if (sum - (int)sum != 0)
            {
                Console.WriteLine("<p>The total value is: <em>{0:F2}</em></p>", sum);
            }
            else
            {
                Console.WriteLine("<p>The total value is: <em>{0:F0}</em></p>", sum);
            }
        }
        else
        {
            Console.WriteLine("<p>The total value is: <em>nothing</em></p>", sum);
        }
    }
}
