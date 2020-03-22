using System.Collections.Generic;

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
    }
}