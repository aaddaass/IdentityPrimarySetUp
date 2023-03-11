using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IDevice
    {
        Device GetDevice(int id);
        IEnumerable<Device> GetAllDevice();
        Device AddDevice(Device Device);
        Device UpdateDevice(Device Device);
        void DeleteDevice(int id);
        List<Device> DeviceList();
    }
}
