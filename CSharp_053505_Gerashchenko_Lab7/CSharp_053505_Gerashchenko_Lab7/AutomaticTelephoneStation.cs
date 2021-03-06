using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_053505_Gerashchenko_Lab7
{
    public class AutomaticTelephoneStation
    {
        private readonly Dictionary<string, Client> _clients;
        private readonly List<Tariff> _availableTariffs;

        public AutomaticTelephoneStation() =>
            (_clients, _availableTariffs) = (new Dictionary<string, Client>(), new List<Tariff>());

        public void RegisterNewTariff(Tariff newTariff)
        {
            if (_availableTariffs.Find(tariff => tariff.Type == newTariff.Type) == null)
                _availableTariffs.Add(newTariff);
            else
                throw new ArgumentException($"Tariff {newTariff.Type} already exists");
        }

        public void RegisterClient(Client client) => _clients.Add(client.Surname.Trim(), client);

        public Client GetClientBySurname(string surname) =>
            _clients.ContainsKey(surname.Trim())
                ? _clients[surname.Trim()]
                : throw new ArgumentException($"Person with {surname} surname is absent in the base");

        public IEnumerable<string> GetTariffsNames() =>
            (from tariff in _availableTariffs
                orderby tariff.CostPerMinute
                select tariff.Type.ToString()).ToList();

        public IEnumerable<string> GetTariffsNames2() =>
            _availableTariffs
                .OrderBy(tariff => tariff.CostPerMinute)
                .Select(tariff => tariff.Type.ToString())
                .ToList();

        public ushort GetAllCallsCost() =>
            (ushort) _clients.Sum(client => client.Value.GetAllCallsCost());

        public string GetClientSurnameWithMaximumCallCost()
        {
            var maximumCost = _clients.ToList().Max(client => client.Value.GetAllCallsCost());
            return _clients.ToList().Find(client => client.Value.GetAllCallsCost() == maximumCost).Value.Surname;
        }

        public ushort GetNumberOfClientsWhoPaidMoreThan(ushort sum) =>
            (ushort) _clients.ToList()
                .Aggregate(0,
                    (result, client) =>
                        result + (client.Value.GetAllCallsCost() >= sum ? 1 : 0)
                );

        public ushort GetNumberOfClientsWhoPaidMoreThan2(ushort sum) =>
            (ushort) (from client in _clients
                where client.Value.GetAllCallsCost() >= sum
                select 1).Sum();
    }
}