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

            if (Books.Count != 0) {
                // TODO List list of Books
            }
            else {
                Console.WriteLine("You don't have any books currently.");
            }

            while (true)
            {
                Console.Write("Do you want create new book (y/n): ");
                if(GetBootInput())
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
       
            }
        //     var book = new Book("Math");

        //     book.AddGrade(6);
        //     book.AddGrade(2);
        //     book.AddGrade(3.5);

        //     book.ShowStats();
        }

        static bool GetBootInput()
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
