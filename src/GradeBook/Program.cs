using System;
using System.Collections.Generic;
using System.Globalization;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("");

            var numbers = new List<double>();

            foreach (var str in args)
            {
                numbers.Add(double.Parse(str));
            }
            
            var sum = 0.0;
            foreach (var str in args)
            {
                sum += double.Parse(str);
            }

            var avg = sum / numbers.Count;

            Console.WriteLine($"Sum is: {sum} and average is: {avg}");
        }
    }
}
