using System;
using System.Collections.Generic;

namespace CSharp_053505_Gerashchenko_Lab9.Domain
{
    public interface ISerializer
    {
        IEnumerable<HeatedBuilding> DeSerializeByLinq(string fileName);
        IEnumerable<HeatedBuilding> DeSerializeXml(string fileName);
        IEnumerable<HeatedBuilding> DeSerializeJson(string fileName);
        void SerializeByLinq(IEnumerable<HeatedBuilding> xxx, string fileName);
        void SerializeXml(IEnumerable<HeatedBuilding> xxx, string fileName);
        void SerializeJson(IEnumerable<HeatedBuilding> xxx, string fileName);
    }

    [Serializable]
    public class HeatedBuilding
    {
        public ushort PowerConsumption { get; set; }
        public HeatedBuilding(ushort a) => PowerConsumption = a;
        public HeatedBuilding() { }
    }
}