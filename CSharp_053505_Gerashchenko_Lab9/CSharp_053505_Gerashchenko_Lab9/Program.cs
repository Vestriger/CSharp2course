using System;
using CSharp_053505_Gerashchenko_Lab9.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_053505_Gerashchenko_Lab9
{
    internal class Program
    {
        static void Main() => Run();

        private static void Run()
        {
            var data = GetDefaultList();

            Serializer.Serializer serialize = new();

            serialize.SerializeXml(data, "test.xml");
            serialize.SerializeJson(data, "test2.json");
            serialize.SerializeByLinq(data, "test3.xml");

            Console.WriteLine("\nFrom JSON: ");
            serialize.DeSerializeJson("test2.json")
                .ToList()
                .ForEach(item => Console.Write($"{item.PowerConsumption} "));

            Console.WriteLine("\nFrom XML: ");
            serialize.DeSerializeXml("test.xml")
                .ToList()
                .ForEach(item => Console.Write($"{item.PowerConsumption} "));

            Console.WriteLine("\nFrom XML (LINQ): ");
            serialize.DeSerializeByLinq("test3.xml")
                .ToList()
                .ForEach(item => Console.Write($"{item.PowerConsumption} "));
        }

        private static List<HeatedBuilding> GetDefaultList()
        {
            List<HeatedBuilding> response = new();
            for (ushort count = 0; count < 5; ++count)
                response.Add(new HeatedBuilding(count));
            return response;
        }
    }
}