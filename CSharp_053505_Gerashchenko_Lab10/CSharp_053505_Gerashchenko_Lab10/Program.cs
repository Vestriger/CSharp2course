using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharp_053505_Gerashchenko_Lab10
{
    internal class Program
    {
        static void Main() => RunDemo(GetDefaultEmployeesPack(), "test.json");

        static void RunDemo(List<Employee> defaultEmployees, string fileName)
        {
            Console.WriteLine("Default: ");
            defaultEmployees.ForEach(item => Console.WriteLine($"\t{item}"));

            var asm = Assembly.LoadFrom("../../../fileService.dll");

            var fileServiceEmployee = asm.GetType("FileService.FileService`1")
                ?.MakeGenericType(typeof(Employee));
            var fileServicer = Activator.CreateInstance(fileServiceEmployee ?? throw new InvalidOperationException());


            MethodInfo fileServiceEmployeeReadFileMethod = fileServiceEmployee.GetMethod("ReadFile");
            MethodInfo fileServiceEmployeeSaveFileMethod = fileServiceEmployee.GetMethod("SaveData");

            fileServiceEmployeeSaveFileMethod?.Invoke(fileServicer, new object[] { defaultEmployees, fileName });

            var dataReadFromFile = (List<Employee>)fileServiceEmployeeReadFileMethod?.Invoke(fileServicer, new object[] { fileName });

            Console.WriteLine("\n\nWritten pack: ");
            dataReadFromFile?.ForEach(item => Console.WriteLine($"\t{item}"));
        }

        private static List<Employee> GetDefaultEmployeesPack() => (new[]
        {
            new Employee("Orlov", 18, true),
            new Employee("Stark", 31, false),
            new Employee("Elkin", 20, false)
        }).ToList();
    }

    public class Employee
    {
        public const string VacationText = "On vacation";
        public const string WorkText = "Working";
        public string Name { get; set; }

        public byte Age { get; set; }

        public bool OnVacation { get; set; }

        public Employee() { }

        public Employee(string name, byte age) =>
            (Name, Age, OnVacation) = (name, age, false);

        public Employee(string name, byte age, bool onVacationNow) =>
            (Name, Age, OnVacation) = (name, age, onVacationNow);

        public override string ToString() =>
            $"{Name} | {Age} years | {(OnVacation ? VacationText : WorkText)}";
    }
}