namespace ContainerManagementSystem
{
    public class RefrigeratedContainer : Container
    {
        public string ProductType { get; private set; }
        public double Temperature { get; private set; }

        public RefrigeratedContainer(string serialNumber, double weight, double height, double depth, double maxCapacity, string productType, double temperature)
            : base(serialNumber, weight, height, depth, maxCapacity)
        {
            ProductType = productType;
            Temperature = temperature;
        }
    }
}