using System;
using System.Globalization;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("");
            
            var i = 0;
            var numbers = new double[args.Length];
            foreach (var str in args)
            {
                numbers[i] = double.Parse(str);
                i++;
            }
            Console.WriteLine(numbers.ToString());
        }
    }
}
