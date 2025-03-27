using System;

namespace ContainerManagementSystem
{
    public class Container
    {
        public string SerialNumber { get; private set; }
        public double MaxCapacity { get; private set; }
        public double Height { get; private set; }
        public double Depth { get; private set; }
        public double Weight { get; private set; }
        public double LoadWeight { get; set; }

        protected Container(string serialNumber, double weight, double height, double depth, double maxCapacity)
        {
            SerialNumber = serialNumber;
            Weight = weight;
            Height = height;
            Depth = depth;
            MaxCapacity = maxCapacity;
            LoadWeight = 0;
        }

        public virtual void Load(double weight)
        {
            if (LoadWeight + weight > MaxCapacity)
            {
                throw new OverfillException("Overfill attempt!");
            }
            LoadWeight += weight;
            Console.WriteLine("Załadowano " + weight + " kg do kontenera " + SerialNumber + ". Łączna waga: " + LoadWeight + " kg.");
        }

        public virtual void Unload()
        {
            Console.WriteLine("Kontener " + SerialNumber + " opróżniony. Wcześniejszy ładunek: " + LoadWeight + " kg.");
            LoadWeight = 0;
        }
        
        public class OverfillException : Exception
        {
            public OverfillException(string message) : base(message) { }
        }
    }
}