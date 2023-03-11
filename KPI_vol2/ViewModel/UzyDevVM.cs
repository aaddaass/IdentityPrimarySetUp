using KPI_vol2.Models;

namespace KPI_vol2.ViewModel
{
    public class UzyDevVM
    {
        public int UzytkownikID { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }
        public int DeviceID { get; set; }
        public Device? Device { get; set; }
    }
}
