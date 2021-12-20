using CSharp_053505_Gerashchenko_Lab5.Entities;

namespace CSharp_053505_Gerashchenko_Lab5.Interfaces
{
    public interface IJes
    {
        void RegisterClient(Client client);

        Client GetClientBySurname(string surname);

        void AddTariff(Tariff tariff);

        ushort CountAllUsersCost();

        string GetTariffsInformation();
    }
}