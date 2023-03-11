using KPI_vol2.Models;

namespace KPI_vol2.ViewModel
{
    public class UzytDevIndexVM
    {
        public IEnumerable<Uzytkownik> uzytkownikIndexVM { get; set; }
        public IEnumerable<Device> devices { get; set; }
    }
}
