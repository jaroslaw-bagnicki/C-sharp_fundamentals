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
            
            var book = new Book("Math");

            book.AddGrade(6);
            book.AddGrade(2);
            book.AddGrade(3.5);
            var grades = book.Grades;
            //grades.Add(5.5);

            var avg = book.AvgGrade;
            var min = book.MinGrade;
            var max = book.MaxGrade;
        
            Console.WriteLine($"Average grade is: {avg:N1}");
            Console.WriteLine($"Lowest grade is: {min:N1}");
            Console.WriteLine($"Highest grade is: {max:N1}");
        }
    }
}
