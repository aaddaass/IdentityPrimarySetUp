using System.ComponentModel.DataAnnotations;
namespace KPI_vol2.Models
{
    public class DeviceType
    {
        [Key]
        public int ID { get; set; }
        public string? NazwaUrzadzenia { get; set; }
        public ICollection<Device>? Devices { get; set; }
    }
}
