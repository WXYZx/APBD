using System;

namespace ContainerManagementSystem
{
    public class LiquidContainer : Container
    {
        private bool isHazardous;

        public LiquidContainer(string serialNumber, double weight, double height, double depth, double maxCapacity, bool isHazardous)
            : base(serialNumber, weight, height, depth, maxCapacity)
        {
            this.isHazardous = isHazardous;
        }

        public override void Load(double weight)
        {
            double allowedCapacity = isHazardous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;
            if (LoadWeight + weight > allowedCapacity)
            {
                SendHazardNotification("Niebezpieczna próba załadunku", SerialNumber);
                throw new OverfillException("Próba przepełnienia kontenera " + SerialNumber);
            }
            base.Load(weight);
        }

        public void SendHazardNotification(string message, string serialNumber)
        {
            Console.WriteLine("Powiadomienie o zagrożeniu dla kontenera " + serialNumber + ": " + message);
        }
    }
}