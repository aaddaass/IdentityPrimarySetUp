using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IUzytkownik
    {
        Uzytkownik GetUzytkownik(int id);
        IEnumerable<Uzytkownik> GetAll();
        Uzytkownik AddUzytkownik(Uzytkownik uzytkownik);
        Uzytkownik UpdateUzytkownik(Uzytkownik uzytkownik);
        Uzytkownik DeleteUzytkownik(int id);
        //void Save(Uzytkownik uzytkownik);
        List<Uzytkownik> uzytkownikList();
    }
}
