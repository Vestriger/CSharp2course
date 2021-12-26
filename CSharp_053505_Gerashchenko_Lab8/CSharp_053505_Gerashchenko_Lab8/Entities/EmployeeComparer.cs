#nullable enable
using System;
using System.Collections.Generic;

namespace CSharp_053505_Gerashchenko_Lab8.Entities
{
    public class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y) =>
            string.Compare(x?.Name, y?.Name, StringComparison.InvariantCulture);
    }
}