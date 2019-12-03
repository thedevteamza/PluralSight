using System;
using GradesBook;

namespace GradesBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Edward's Book");
            
            while(true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit.");

                var input = Console.ReadLine();

                if (input == "q")
                    break; 

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book name {book.Name}:");
            Console.WriteLine($"The lowest grade is: {stats.Low:N1}.");
            Console.WriteLine($"The highest grade is: {stats.High:N2}.");
            Console.WriteLine($"The average grade is: {stats.Average:N3}.");
            Console.WriteLine($"The letter grade is: {stats.Letter}.");
        }
    }
}
