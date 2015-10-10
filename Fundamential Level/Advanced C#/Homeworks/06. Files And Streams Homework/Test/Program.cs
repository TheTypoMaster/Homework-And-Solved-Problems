using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex rgx = new Regex(@"\s+");

            string command = "a   4 r";

            command = rgx.Replace(command, "");

        }
    }
}
