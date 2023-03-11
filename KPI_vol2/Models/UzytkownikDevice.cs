using System.Collections.Generic;

namespace KPI_vol2.Models
{
    public class UzytkownikDevice
    {
        public int UzytkownikID { get; set; }
        //public IEnumerable<Uzytkownik> Uzytkowniks { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }
        public int DeviceID { get; set; }
       // public IEnumerable<Device> Devices { get; set; }
        public Device? Device { get; set; }
    }
}
