using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IUrzyt_Device
    {
        UzytkownikDevice  GetUzytkownikDevice(int id);
        IEnumerable<UzytkownikDevice> GetAllUzytkownikDevice();
        UzytkownikDevice AddUzytkownikDevice(UzytkownikDevice uzytkownikDevice);
        UzytkownikDevice UpdateUzytkownikDevice(UzytkownikDevice uzytkownikDevice);
        void DeleteUzytkownikDevice(int id);
    }
}
