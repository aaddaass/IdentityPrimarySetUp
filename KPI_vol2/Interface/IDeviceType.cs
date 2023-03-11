using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IDeviceType
    {
        DeviceType GetDeviceType(int id);
        IEnumerable<DeviceType> GetAllDeviceType();
        DeviceType AddDeviceType(DeviceType DeviceType);
        DeviceType UpdateDeviceType(DeviceType DeviceType);
        void DeleteDeviceType(int id);
        List<DeviceType> DeviceTypeList();
    }
}
