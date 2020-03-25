using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        static readonly double MIN_GRADE = 0.0;
        static readonly double MAX_GRADE = 100.0;
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
            if (!ValidateGrade(grade))
            {
                Console.WriteLine("Invalid grade!");
                return;
            }
            _grades.Add(grade);
            Console.WriteLine("Grade successfully added.");
        }

        private bool ValidateGrade(double grade)
        {
            return (grade >= MIN_GRADE && grade <= MAX_GRADE) ? true : false;
        }

        public Nullable<double> AvgGrade {
            get
            {
                if (Grades.Count == 0) return null;
                var acc = _grades.Aggregate((sum: 0.0, count: 0), (acc, curr) => (acc.sum + curr, acc.count + 1));
                return acc.sum / acc.count;
            }
        }

        public static Nullable<char> ConvertTotLetterGrade(double? grade) 
        {
            if (grade == null)
            {
                return null;
            }

            if (grade > 100 || grade < 0) {
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade have to be between 0 and 100");
            }

            switch(grade)
            {
                case var g when g >= 90:
                    return 'A';
                case var g when g >= 80:
                    return 'B';
                case var g when g >= 70:
                    return 'C';
                case var g when g >= 60:
                    return 'D';
                case var g when g >= 0:
                default:
                    return 'F';
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

        public Stats GetStats()
        {
            return new Stats { 
                AvgGrade = AvgGrade,
                MinGrade = MinGrade,
                MaxGrade = MaxGrade,
            };
        }

        public void ShowStats()
        {
            var stats = GetStats();
            Console.WriteLine($"Statistics for {Name} book:");
            Console.WriteLine($"There is {_grades.Count} grades");
            Console.WriteLine($"Average grade is {stats.AvgGrade:N1}");
            Console.WriteLine($"Lowest grade is {stats.MinGrade:N1}");
            Console.WriteLine($"Highest grade is {stats.MaxGrade:N1}");
        }
    }
}