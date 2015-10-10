using System;
using System.Text.RegularExpressions;
using System.Linq;

class ValidUsernames
{
    static void Main()
    {
        string splitPattern = @"[\s*?\/\\\(\)]+";
        string usernamePattern = @"\b([a-zA-Z][\w0-9]{2,24})";
        string text = "ds3bhj       y1ter/wfsdg   \n 1nh_jgf ds2c_vbg\\4htref";

        Regex regexSplit = new Regex(splitPattern);
        Regex regexValidateUsername = new Regex(usernamePattern);

        //regexValidateUsername

        //string[] usernames = regexSplit.Split(text).Select(i => i == regexValidateUsername.Match(i));

    }
}
