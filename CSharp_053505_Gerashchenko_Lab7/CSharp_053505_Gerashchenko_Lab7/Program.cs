using System;
using System.Collections.Generic;

namespace CSharp_053505_Gerashchenko_Lab7
{
    internal static class Program
    {
        private static void Main() => RunApplicationDemonstration();


        private static void RunApplicationDemonstration()
        {
            var station = new AutomaticTelephoneStation();

            var tariffs = GetDefaultTariffsPack();
            var clients = GetDefaultClientsPack();

            tariffs.ForEach(station.RegisterNewTariff);
            clients.ForEach(station.RegisterClient);

            /* list of names of all tariffs, sorted by cost */
            Console.WriteLine(string.Join(", ", station.GetTariffsNames()));


            station.GetClientBySurname(clients[0].Surname)?.RegisterCall(new SingleCall(tariffs[2], 5));
            station.GetClientBySurname(clients[0].Surname)?.RegisterCall(new SingleCall(tariffs[3], 50));
            station.GetClientBySurname(clients[3].Surname)?.RegisterCall(new SingleCall(tariffs[0], 1));

            /* total cost of all calls*/
            Console.WriteLine(station.GetAllCallsCost());


            Console.WriteLine(station.GetClientBySurname(clients[0].Surname)?.GetAllCallsCost());
            tariffs[2].UpdateCost(8); // changing actual tariff cost
            station.GetClientBySurname(clients[0].Surname)?.RegisterCall(new SingleCall(tariffs[2], 5));
            Console.WriteLine(station.GetClientBySurname(clients[0].Surname)?.GetAllCallsCost());


            station.GetClientBySurname(clients[4].Surname)?.RegisterCall(new SingleCall(tariffs[0], 20));
            Console.WriteLine(station.GetClientSurnameWithMaximumCallCost());


            station.GetClientBySurname("Rogers")?.RegisterCall(new SingleCall(tariffs[1], 30));
            Console.WriteLine(station.GetNumberOfClientsWhoPaidMoreThan(900));


            Console.WriteLine(string.Join(", ", station.GetClientBySurname("Gerashchenko")?.GetSumsForEveryUsedTariff() ?? throw new InvalidOperationException()));
        }

        private static List<Client> GetDefaultClientsPack() => new()
        {
            new Client("Gerashchenko"),
            new Client("Elkin"),
            new Client("Pygachev"),
            new Client("Orlov"),
            new Client("Maximov"),
            new Client("Stark"),
            new Client("Rogers")
        };

        private static List<Tariff> GetDefaultTariffsPack() => new()
        {
            new Tariff(TariffType.Lux, 60),
            new Tariff(TariffType.International, 30),
            new Tariff(TariffType.Local, 10),
            new Tariff(TariffType.Intercity, 12)
        };
    }
}