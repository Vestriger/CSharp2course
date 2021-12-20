using CSharp_053505_Gerashchenko_Lab6.Interfaces;

namespace CSharp_053505_Gerashchenko_Lab6.Entities
{
    public enum TariffType
    {
        Water = 0,
        LightAndWater = 1,
        GasAndLightAndWater = 2
    }

    public class Tariff : ITariff
    {
        private const string Currency = "BYN";
        public TariffType Type { get; private set; }
        public ushort Price { get; set; }

        public Tariff(TariffType type, ushort price) => (Type, Price) = (type, price);

        public string GetInformation() => $"{Type.ToString()} | {Price}{Currency}/month";
    }
}