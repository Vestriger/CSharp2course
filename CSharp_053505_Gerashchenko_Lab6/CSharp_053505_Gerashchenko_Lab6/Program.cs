using System;
using System.Collections.Generic;
using System.Linq;
using CSharp_053505_Gerashchenko_Lab6.Collections;
using CSharp_053505_Gerashchenko_Lab6.Entities;

namespace CSharp_053505_Gerashchenko_Lab6
{
    internal class Program
    {
        private static void Main() => RunAppDemonstration();


        private static void RunAppDemonstration()
        {
            var jes = new Jes();
            var journalLogger = new Journal();

            jes.AddClientNotification +=
                (description, client) =>
                    journalLogger.AddEvent(client.Surname, description);

            jes.AddTariffNotification +=
                (description, tariff) =>
                    journalLogger.AddEvent(tariff.Type.ToString(), description);


            var testCollectionTariffs = new CustomCollection<Tariff>();
            GetDefaultTariffsPack().ToList().ForEach(testCollectionTariffs.Add);
            foreach (var tariff in testCollectionTariffs)
                jes.AddTariff(tariff);

            journalLogger.PrintRegisteredEvents();
            
            GetDefaultClientsPack().ToList().ForEach(jes.RegisterClient);

            journalLogger.PrintRegisteredEvents();

            jes.RegisterUseNotification += ClientUseSomething;

            jes.RegisterUseForClient(
                jes.GetClientBySurname("Dneprov"),
                new SingleUse(new Tariff(TariffType.Water, 25), 2)
            ); 
            
            try
            {
                testCollectionTariffs.Remove(GetDefaultTariffsPack().ToList()[0]);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            /* Unable to remove the element. Not existing item. */
        }


        private static IEnumerable<Tariff> GetDefaultTariffsPack() => new[]
        {
            new Tariff(TariffType.Water, 100),
            new Tariff(TariffType.LightAndWater, 200),
            new Tariff(TariffType.GasAndLightAndWater, 300)
        };

        private static IEnumerable<Client> GetDefaultClientsPack() => new[]
        {
            new Client("Elkin"),
            new Client("Dneprov")
        };

        private static void ClientUseSomething(string a, string b) =>
            Console.WriteLine($"{a} use something & spent {b}");
    }
}