namespace CSharp_053505_Gerashchenko_Lab7
{
    public class SingleCall
    {
        public Tariff UsedTariff { get; }
        private ushort _duration;

        public SingleCall(Tariff tariff, ushort duration) =>
            (UsedTariff, _duration, Cost) = (tariff, duration, (ushort) (tariff.CostPerMinute * duration));

        public ushort Cost { get; }
    }
}