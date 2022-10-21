using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IZdarzenia
    {
        Zdarzenia GetZdarzenia(int id);
        IEnumerable<Zdarzenia> GetAllZdarzenia();
        Zdarzenia AddZdarzenia(Zdarzenia zdarzenia);
        Zdarzenia UpdateZdarzenia(Zdarzenia zdarzenia);
        void DeleteZdarzenia(int id);   
    }
}
