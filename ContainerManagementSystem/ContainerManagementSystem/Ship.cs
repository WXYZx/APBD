using System;
using System.Collections.Generic;

namespace ContainerManagementSystem
{
    public class Ship
    {
       private List<Container> containers = new List<Container>();
        private double maxSpeed;
        private int maxContainers;
        private double maxWeight;

        public Ship(double maxSpeed, int maxContainers, double maxWeight)
        {
            this.maxSpeed = maxSpeed;
            this.maxContainers = maxContainers;
            this.maxWeight = maxWeight * 1000;
        }

        public void LoadContainer(Container container)
        {
            double totalWeight = GetTotalWeight();
            if (containers.Count >= maxContainers)
            {
                Console.WriteLine("Nie można załadować więcej kontenerów, osiągnięto maksymalną pojemność.");
                return;
            }
            if (totalWeight + container.Weight + container.LoadWeight > maxWeight)
            {
                Console.WriteLine("Nie można załadować kontenera, przekroczono maksymalną wagę.");
                return;
            }
            containers.Add(container);
            Console.WriteLine("Kontener " + container.SerialNumber + " załadowany na statk.");
        }

        public void UnloadContainer(Container container)
        {
            if (containers.Remove(container))
            {
                container.Unload();
                Console.WriteLine("Kontener " + container.SerialNumber + " wyładowany ze statku.");
            }
            else
            {
                Console.WriteLine("Kontener " + container.SerialNumber + " nie ma na statku.");
            }
        }

        public void ReplaceContainer(string serialNumber, Container newContainer)
        {
            Container containerToReplace = containers.Find(c => c.SerialNumber == serialNumber);
            if (containerToReplace != null)
            {
                containers.Remove(containerToReplace);
                containers.Add(newContainer);
                Console.WriteLine("Kontener " + serialNumber + " zastąpiony przez " + newContainer.SerialNumber + ".");
            }
            else
            {
                Console.WriteLine("Nie znaleziono kontenera z tym numerem na tym statku: " + serialNumber);
            }
        }

        public void TransferContainer(Ship otherShip, Container container)
        {
            if (containers.Contains(container))
            {
                containers.Remove(container);
                otherShip.containers.Add(container);
                Console.WriteLine("Kontener " + container.SerialNumber + " przeniesiony na inny statk.");
            }
            else
            {
                Console.WriteLine("Kontener " + container.SerialNumber + " nie znaleziony na tym statku.");
            }
        }

        public void PrintShipInfo()
        {
            Console.WriteLine("Container Ship Info:");
            Console.WriteLine("  Maksymalna prędkość: " + maxSpeed + " węzłów");
            Console.WriteLine("  Maksymalna ilość kontnerów: " + maxContainers);
            Console.WriteLine("  Maksymalna nośność: " + (maxWeight / 1000) + " ton");
            Console.WriteLine("  Kontnerów na pokładzie: " + containers.Count);
            Console.WriteLine("  Całkowita masa na pokładzie: " + (GetTotalWeight() / 1000) + " ton");
        }

        private double GetTotalWeight()
        {
            double totalWeight = 0;
            foreach (var container in containers)
            {
                totalWeight += container.Weight + container.LoadWeight;
            }
            return totalWeight;
        }
    }
}
