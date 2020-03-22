using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        string _name;
        List<double> _grades;
        public readonly ReadOnlyCollection<double> Grades;

        public Book(string name)
        {
            _name = name;
            _grades = new List<double>();
            Grades = _grades.AsReadOnly();
        }

        public string Name { get { return _name; } }

        public void AddGrade(double grade)
        {
            _grades.Add(grade);
        }

        public Nullable<double> AvgGrade {
            get
            {
                if (Grades.Count == 0) return null;
                var acc = _grades.Aggregate((sum: 0.0, count: 0), (acc, curr) => (acc.sum + curr, acc.count + 1));
                return acc.sum / acc.count;
            }
        }

        public Nullable<double> MinGrade {
            get
            {
                if (Grades.Count == 0) return null;
                return _grades.Aggregate(double.MaxValue, (acc, curr) => Math.Min(acc, curr));
            }
        }

        public Nullable<double> MaxGrade {
            get 
            {
                if (Grades.Count == 0) return null;
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