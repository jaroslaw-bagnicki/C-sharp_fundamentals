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
            book.AddGrade(1);
            book.AddGrade(3);
            book.AddGrade(5);

            Assert.Equal(1, book.MinGrade);
            Assert.Equal(5, book.MaxGrade);
            Assert.Equal(((1+3+5)/3), book.AvgGrade);
            book.MinGrade.Should().Be(1);
            book.MaxGrade.Should().Be(5);
            book.AvgGrade.Should().Be(((1+3+5)/3));
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
             var result = Book.ConvertTotLetterGrade(grade);
             result.Should().Be(expected);
        }

        [Theory]
        [InlineData(999)]
        [InlineData(-1)]
        public void TestConvertToLetterGradeEx(double grade)
        {
            Action convert = () => Book.ConvertTotLetterGrade(grade);

            convert.Should().Throw<ArgumentOutOfRangeException>()
                .And.ParamName.Should().Be("grade");
        }
    }
}
