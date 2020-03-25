using Xunit;
using FluentAssertions;
using System;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void TestGetters()
        {
            var book = new Book("Test book");
            book.AddGrade(79.0);
            book.AddGrade(84.0);
            book.AddGrade(55.0);

            Assert.Equal(55.0, book.MinGrade);
            Assert.Equal(84.0, book.MaxGrade);
            Assert.Equal(72.7, book.AvgGrade);
            book.MinGrade.Should().Be(55.0);
            book.MaxGrade.Should().Be(84.0);
            book.AvgGrade.Should().Be(72.7);
        }

        [Fact]
        public void TestGetStatsForBookWithNoGrades()
        {
            var book = new Book("Test book");

            var stats = new Stats {
                AvgGrade = null,
                AvgGradeLetter = null,
                MinGrade = null,
                MaxGrade = null,
            };

            var result = book.GetStats();
            result.Should().BeEquivalentTo(stats);
        }

        [Theory]
        [InlineData(new []{ 55.0, 79.0, 84.0 }, 72.7, 'C', 55.0, 84.0)]
        public void TestGetStats(double[] grades, double avg, char avgLetter, double min, double max)
        {
            var book = new Book("Test book");

            foreach (var grade in grades)
            {
                book.AddGrade(grade);
            }

            var stats = new Stats(avg,avgLetter,min, max);

           book.GetStats().Should().BeEquivalentTo(stats);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(99.1, 'A')]
        [InlineData(85.0, 'B')]
        [InlineData(71.9, 'C')]
        [InlineData(66.6, 'D')]
        [InlineData(59.9, 'F')]
        [InlineData(33.3, 'F')]
        public void TestConvertToLetterGrade(Nullable<double> grade, Nullable<char> expected)
        {
             var result = Book.ConvertGradeTotLetterGrade(grade);
             result.Should().Be(expected);
        }

        [Theory]
        [InlineData(999)]
        [InlineData(-1)]
        public void TestConvertToLetterGradeEx(double grade)
        {
            Action convert = () => Book.ConvertGradeTotLetterGrade(grade);
            convert.Should().Throw<ArgumentOutOfRangeException>()
                .And.ParamName.Should().Be("grade");
        }
    }
}
