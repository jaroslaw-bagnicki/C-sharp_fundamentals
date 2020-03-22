using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void TestGetters()
        {
            var book = new Book("Test book");
            book.AddGrade(1);
            book.AddGrade(3);
            book.AddGrade(5);

            Assert.Equal(1, book.MinGrade);
            Assert.Equal(5, book.MaxGrade);
            Assert.Equal(((1+3+5)/3), book.AvgGrade);
        }

        [Fact]
        public void TestGetStats()
        {
            var book = new Book("Test book");
            book.AddGrade(1);
            book.AddGrade(3);
            book.AddGrade(5);

            var stats = new Stats {
                AvgGrade = (1+3+5)/3,
                MinGrade = 1,
                MaxGrade = 5,
            };

            Assert.Equal<Stats>(stats, book.GetStats());
        }
    }
}
