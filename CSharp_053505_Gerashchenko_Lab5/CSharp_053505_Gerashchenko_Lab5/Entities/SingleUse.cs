using System;
using CSharp_053505_Gerashchenko_Lab5.Interfaces;

namespace CSharp_053505_Gerashchenko_Lab5.Entities
{
    public class SingleUse : ISingleUse
    {
        private const string DurationMeasurementUnits = "month";
        private const string CurrencyMeasurementUnits = "BYN";
        private readonly Tariff _usedTarrif;
        private readonly byte _duration;
        private ushort _totalCost;

        public SingleUse(Tariff tariff, byte duration) =>
            (_usedTarrif, _duration, _totalCost) = (tariff, duration, (ushort) (tariff.Price * duration));

        public override string ToString() =>
            $"{Enum.GetName(typeof(TariffType), _usedTarrif.Type)}; " +
            $"{_duration} {DurationMeasurementUnits}; " +
            $"{_totalCost} {CurrencyMeasurementUnits}";

        public void RecountTotalCosts() => _totalCost = (ushort)(_duration * _usedTarrif.Price);

        public ushort TotalCost => _totalCost;
    }
}