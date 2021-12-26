using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharp_053505_Gerashchenko_Lab8.Entities;

namespace CSharp_053505_Gerashchenko_Lab8
{
    internal static class Program
    {
        private static void Main()
        {
            var session = new FileService();

            var employedByFactory = GetDefaultEmployeesPack();
            var (firstFileName, secondFileName) =
                (GetRandomStringFileName(), GetRandomStringFileName());

            Console.WriteLine(firstFileName);
            Console.WriteLine(secondFileName);

            session.SaveData(employedByFactory, firstFileName);

            File.Move(firstFileName, secondFileName);

            var testReading = session.ReadFile(secondFileName).ToList();
            testReading.Sort(new EmployeeComparer());
            testReading.ForEach(Console.WriteLine);
        }


        #region GetDefaultEmployeesPack()

        private static IEnumerable<Employee> GetDefaultEmployeesPack() => new[]
        {
            new Employee("John", 300, true),
            new Employee("Mike", 300, true),
            new Employee("Walter", 1000, false),
            new Employee("Mark", 500, false),
            new Employee("Bob", 650, false)
        };

        #endregion

        #region GetRandomStringFileName

        private static string GetRandomStringFileName() =>
            new string(Enumerable
                .Repeat("abcdefghigklmnopqrstuvwxyz0123456789", new Random().Next(7, 10))
                .Select(s => s[new Random().Next(s.Length)]).ToArray()) + ".txt";

        #endregion
    }
}