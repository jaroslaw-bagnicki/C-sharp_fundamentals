using System.Globalization;

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

            book.ShowStats();
        }
    }
}
