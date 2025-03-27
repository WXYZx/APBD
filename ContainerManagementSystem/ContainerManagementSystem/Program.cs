namespace ContainerManagementSystem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer("R123", 20, 2, 3, 5, "Chocolate", 18);
            LiquidContainer liquidContainer1 = new LiquidContainer("L232", 10, 2, 3, 15, true);
            GasContainer gasContainer1 = new GasContainer("G839", 15, 2, 3, 10, 14);

            Ship ship1 = new Ship(30, 5, 100);

            ship1.LoadContainer(refrigeratedContainer);
            ship1.LoadContainer(liquidContainer1);
            ship1.LoadContainer(gasContainer1);

            ship1.PrintShipInfo();

            ship1.UnloadContainer(refrigeratedContainer);

            ship1.PrintShipInfo();

            LiquidContainer newLiquidContainer = new LiquidContainer("L456", 12, 2, 3, 5, false);
            ship1.ReplaceContainer("L232", newLiquidContainer);

            ship1.PrintShipInfo();

            Ship ship2 = new Ship(28, 4, 80);
            ship1.TransferContainer(ship2, gasContainer1);

            ship1.PrintShipInfo();
            ship2.PrintShipInfo();
        }
    }
}