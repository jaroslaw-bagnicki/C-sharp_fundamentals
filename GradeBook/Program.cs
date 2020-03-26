using System;
using System.Collections.Generic;
using System.Globalization;

namespace GradeBook
{
    class Program
    {
        static List<Book> Books = new List<Book>();
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("");

            
            Console.WriteLine("Hello in GradeBook App \n");

            while (true)
            {
                if (Books.Count != 0) {
                    Console.WriteLine($"You have {Books.Count} {(Books.Count == 1 ? "book" : "books")} currently.");
                    // TODO List list of Books
                    // TODO Ask use existing or create new one
                }
                else {
                    Console.WriteLine("You don't have any books currently.");
                }

                Console.Write("Do you want create new book? (y/n) ");
                if(GetBoolInput())
                {
                    Console.Write("Enter name for book: ");
                    var name = GetStringInput();
                    Console.WriteLine("Name: " + name);
                }
            }
        }

        private static Book CreateNewBook()
        {
            Console.Write("Enter name for book: ");
            var name = GetStringInput();
            var book = new Book(name);
            Console.Write("Do you want add grades? (y/n) ");
            if(GetBoolInput())
            {
                while(true)
                {
                    Console.Write("Enter grade (or enter to finish): ");
                    var grade = GetNumberInput();
                    book.AddGrade(grade);
                }
            }

            return book;
        }

        private static string GetStringInput(bool allowEmpty = false)
        {
            var input = string.Empty;
            do
            {
                try
                {
                    input = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return string.Empty;
                }
            } while (allowEmpty || string.IsNullOrWhiteSpace(input));
            return input;
        }

        private static bool GetBoolInput()
        {
            char input = '\0';
            while(true)
            {
                try
                {
                    input = Console.ReadKey(true).KeyChar;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
                switch(input)
                {
                    case 'y':
                    case 'Y':
                        Console.Write($"{input}\n");
                        return true;
                    case 'n':
                    case 'N':
                        Console.Write($"{input}\n");
                        return false;
                }
            }
        }
    }
}
