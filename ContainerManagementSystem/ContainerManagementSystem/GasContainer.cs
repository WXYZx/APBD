using System;

namespace ContainerManagementSystem
{
    public class GasContainer : Container
    {
        private double pressure;

        public GasContainer(string serialNumber, double containerWeight, double height, double depth, double maxCapacity, double pressure)
            : base(serialNumber, containerWeight, height, depth, maxCapacity)
        {
            this.pressure = pressure;
        }

        public override void Load(double weight)
        {
            if (LoadWeight + weight > MaxCapacity)
            {
                SendHazardNotification("Próba załadowania nadmierną wagą ", SerialNumber);
                throw new OverfillException("Próba przepełnienia kontenera gazowego " + SerialNumber);
            }
            base.Load(weight);
        }

        public override void Unload()
        {
            LoadWeight = MaxCapacity * 0.05;
            Console.WriteLine("Gas container " + SerialNumber + " partially unloaded. Remaining weight: " + LoadWeight + " kg.");
        }

        public void SendHazardNotification(string message, string serialNumber)
        {
            Console.WriteLine("Hazard notification for container " + serialNumber + ": " + message);
        }
    }
}