using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        List<double> Grades;

        public Book()
        {
            Grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            Grades.Add(grade);
        }

        public List<double> GetGrades()
        {
            return Grades;
        }
    }
}