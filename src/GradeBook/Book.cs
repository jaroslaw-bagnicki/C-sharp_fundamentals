using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeBook
{
    class Book
    {
        string _name;
        List<double> _grades;

        public Book(string name)
        {
            _name = name;
            _grades = new List<double>();
        }

        public ReadOnlyCollection<double> Grades { get { return _grades.AsReadOnly(); } }
        public string Name { get { return _name; } }

        public void AddGrade(double grade)
        {
            _grades.Add(grade);
        }

        public double AvgGrade {
            get {
                 var acc = _grades.Aggregate((sum: 0.0, count: 0), (acc, curr) => (acc.sum + curr, acc.count + 1));
                return acc.sum / acc.count;
            }
        }

        public double MinGrade {
            get {
                return _grades.Aggregate(double.MaxValue, (acc, curr) => Math.Min(acc, curr));
            }
        }

        public double MaxGrade {
            get {
                return _grades.Aggregate(double.MinValue, (acc, curr) => Math.Max(acc, curr));
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"Statistics for {Name} book:");
            Console.WriteLine($"There is {_grades.Count} grades");
            Console.WriteLine($"Average grade is {AvgGrade:N1}");
            Console.WriteLine($"Lowest grade is {MinGrade:N1}");
            Console.WriteLine($"Highest grade is {MaxGrade:N1}");
        }
    }
}