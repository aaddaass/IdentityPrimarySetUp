using System.ComponentModel.DataAnnotations;
namespace KPI_vol2.Models
{
    public class Device
    {
        [Key]
        public int         ? Id              { get; set; }
        public string      ? SerialNo        { get;set; }
        public string      ? IMEI            { get; set; }
        public string      ? Model           { get; set; }
        public string      ? DomainName      { get; set; }
        public int          DeviceTypeId    { get; set; }
        public DeviceType?   DeviceType      { get; set; }
        //public int         ? UzytkownikID    { get; set; }
        //public Uzytkownik  ? Uzytkownik      { get; set; }
        public ICollection<UzytkownikDevice> uzytkownikDevices { get; set; }
    }
}
