using System.Collections.Generic;
using CSharp_053505_Gerashchenko_Lab8.Entities;

namespace CSharp_053505_Gerashchenko_Lab8.Interfaces
{
    public interface IFileService
    {
        IEnumerable<Employee> ReadFile(string fileName);
        void SaveData(IEnumerable<Employee> data, string fileName);
    }
}