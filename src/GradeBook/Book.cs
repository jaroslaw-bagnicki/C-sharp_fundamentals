using System;
using System.Collections.Generic;
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

        public List<double> Grades { get { return _grades; } }
        public string Name { get { return _name; } }

        public void AddGrade(double grade)
        {
            Grades.Add(grade);
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
    }
}