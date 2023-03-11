using KPI_vol2.Models;

namespace KPI_vol2.ViewModel
{
    public class DeviceVM
    {
        public int Id { get; set; }
        public string? SerialNo { get; set; }
        public string? IMEI { get; set; }
        public string? Model { get; set; }
        public string? DomainName { get; set; }
        public int DeviceTypeId { get; set; }
        public DeviceType? DeviceType { get; set; }
    }
}
