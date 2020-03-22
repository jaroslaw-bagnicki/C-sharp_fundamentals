using System;
using System.Globalization;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("");
            
            double result = 0;
            var numbers = new double[args.Length];
            foreach (var str in args)
            {
                result += double.Parse(str);
            }
            Console.WriteLine($"Sum is: {result}");
        }
    }
}
