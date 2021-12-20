using CSharp_053505_Gerashchenko_Lab6.Entities;

namespace CSharp_053505_Gerashchenko_Lab6.Interfaces
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