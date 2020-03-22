using System;
using System.Globalization;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("");

            (var sum, var count) = (0.0, 0);

            var numbers = args.Select(str => double.Parse(str)).ToList();
        
            var acc = args
                .Select(str => double.Parse(str))
                .Aggregate((sum: 0.0, count: 0), (acc, curr) => (acc.sum + curr, acc.count + 1));

            var avg = acc.sum / acc.count;

            Console.WriteLine($"Sum is: {acc.sum} and average is: {avg}");
        }
    }
}
