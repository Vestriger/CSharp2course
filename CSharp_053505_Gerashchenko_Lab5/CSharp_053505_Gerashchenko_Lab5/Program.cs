
using System;
using System.Collections.Generic;
using System.Linq;
using CSharp_053505_Gerashchenko_Lab5.Collections;
using CSharp_053505_Gerashchenko_Lab5.Entities;

namespace CSharp_053505_Gerashchenko_Lab5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
             var jes = new Jes();


            var testCollectionTariffs = new CustomCollection<Tariff>();
            GetDefaultTariffsPack().ToList().ForEach(testCollectionTariffs.Add);
            foreach (var tariff in testCollectionTariffs)
                jes.AddTariff(tariff);


            Console.WriteLine(jes.GetTariffsInformation());

            GetDefaultClientsPack().ToList().ForEach(jes.RegisterClient);
            Console.WriteLine(jes.GetClientsInformation());

            jes.GetClientBySurname("Ejikov")?.RegisterUsage(new SingleUse(testCollectionTariffs[0], 5));
            Console.WriteLine(jes.GetClientsInformation());

            Console.WriteLine(testCollectionTariffs[(ushort) (testCollectionTariffs.Count - 1)].GetInformation());

            jes.GetClientBySurname("Glyharev")?.RegisterUsage(new SingleUse(testCollectionTariffs[1], 10));
            Console.WriteLine(jes.GetClientsInformation());
            Console.WriteLine(jes.CountAllUsersCost());
        }


        private static IEnumerable<Tariff> GetDefaultTariffsPack() => new[]
        {
            new Tariff(TariffType.Water, 100),
            new Tariff(TariffType.LightAndWater, 200),
            new Tariff(TariffType.GasAndLightAndWater, 300)
        };

        private static IEnumerable<Client> GetDefaultClientsPack() => new[]
        {
            new Client("Glyharev"),
            new Client("Ejikov"),
            new Client("Elkin")
        };
        }
    }
