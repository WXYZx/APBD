namespace ContainerManagementSystem
{
    public interface IHazardNotifier
    {
        void SendHazardNotification(string message, string serialNumber);
    }
}