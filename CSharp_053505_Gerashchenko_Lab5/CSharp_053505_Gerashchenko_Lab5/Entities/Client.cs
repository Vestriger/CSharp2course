using System.IO.Ports;
using CSharp_053505_Gerashchenko_Lab5.Collections;
using CSharp_053505_Gerashchenko_Lab5.Interfaces;

namespace CSharp_053505_Gerashchenko_Lab5.Entities

{
    public class Client : IClient
    {
        private readonly CustomCollection<SingleUse> _usages;

        public string Surname { get; private set; }

        public Client(string surname) =>
            (Surname, _usages) = (surname, new CustomCollection<SingleUse>());

        public void RegisterUsage(SingleUse use) => _usages.Add(use);
        

        public ushort UsagesCount => _usages.Count;

        public void Rename(string surname) =>
            Surname = surname.Trim() != "" ? surname.Trim() : Surname;

        public ushort GetAllUsagesCost()
        {
            ushort response = 0;
            _usages.Reset();
            var call = _usages.Current();
            while (call != null)
            {
                response += call.TotalCost;
                _usages.Next();
                call = _usages.Current();
            }

            _usages.Reset();
            return response;
        }

        public string GetInformation() =>
            $"{Surname}, usages: {UsagesCount}, total spent: {GetAllUsagesCost()}";
    }
}