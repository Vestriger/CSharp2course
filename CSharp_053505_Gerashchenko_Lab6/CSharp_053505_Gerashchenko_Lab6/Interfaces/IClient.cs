using CSharp_053505_Gerashchenko_Lab6.Entities;

namespace CSharp_053505_Gerashchenko_Lab6.Interfaces
{
    public interface IClient
    {
        void RegisterUsage(SingleUse use);

        void Rename(string surname);

        ushort GetAllUsagesCost();
    }
}