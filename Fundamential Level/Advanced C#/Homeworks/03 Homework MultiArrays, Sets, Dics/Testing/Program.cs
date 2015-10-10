using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Parse("2014/07/24", new CultureInfo("bg-BG"));
            int month = dt.Month;

            Console.WriteLine(month);
        }
    }
}
