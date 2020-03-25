using System;

namespace GradeBook
{
    public class Stats
    {
        public double? AvgGrade;
        public char? AvgGradeLetter;
        public double? MinGrade;
        public double? MaxGrade;

        public Stats() {}
        public Stats(double? avgGrade, char? avgGradeLetter, double? minGrade, double? maxGrade)
        {
            AvgGrade = avgGrade;
            AvgGradeLetter = avgGradeLetter;
            MinGrade = minGrade;
            MaxGrade = maxGrade;   
        }
    }

}