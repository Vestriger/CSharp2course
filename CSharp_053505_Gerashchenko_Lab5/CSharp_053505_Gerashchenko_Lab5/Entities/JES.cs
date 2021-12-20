using System;
using CSharp_053505_Gerashchenko_Lab5.Collections;
using CSharp_053505_Gerashchenko_Lab5.Interfaces;

namespace CSharp_053505_Gerashchenko_Lab5.Entities
{
    public class Jes : IJes
    {
        private readonly ICustomCollection<Tariff> _tariffs;
        private readonly ICustomCollection<Client> _clients;


        public Jes() =>
            (_tariffs, _clients) = (new CustomCollection<Tariff>(), new CustomCollection<Client>());

        public void AddTariff(Tariff tariff) => _tariffs.Add(tariff);

        public void RegisterClient(Client client) => _clients.Add(client);

        public Client GetClientBySurname(string surname)
        {
            _clients.Reset();
            var currentElement = _clients.Current();
            while (currentElement != null && currentElement.Surname != surname)
            {
                if (currentElement.Surname == surname)
                    break;
                _clients.Next();
                currentElement = _clients.Current();
            }

            return currentElement;
        }

        public ushort CountAllUsersCost()
        {
            ushort response = 0;
            _clients.Reset();
            var client = _clients.Current();
            while (client != null)
            {
                response += client.GetAllUsagesCost();
                _clients.Next();
                client = _clients.Current();
            }

            _clients.Reset();
            return response;
        }

        public string GetTariffsInformation()
        {
            var response = "";
            _tariffs.Reset();
            var tariff = _tariffs.Current();
            while (tariff != null)
            {
                tariff = _tariffs.Current();
                response += tariff.GetInformation() + ", ";
                _tariffs.Next();
                tariff = _tariffs.Current();
            }

            _tariffs.Reset();
            return response.Length > 0 ? response.Remove(response.Length - 1).Remove(response.Length - 2) : response;
        }

        public string GetClientsInformation()
        {
            Console.WriteLine("-----------------------------------");
            var response = "";
            _clients.Reset();
            var client = _clients.Current();
            while (client != null)
            {
                client = _clients.Current();
                response += client.GetInformation() + "\n ";
                _clients.Next();
                client = _clients.Current();
            }

            _clients.Reset();
            return response.Length > 0 ? response.Remove(response.Length - 1).Remove(response.Length - 2) : response;
        }
    }
}