using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("");
            
            var book = new Book();

            book.AddGrade(6);
            book.AddGrade(2);
            book.AddGrade(3.5);
            var grades = book.GetGrades();
            book.AddGrade(5.5);

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
