using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IZdarzenie
    {
        Zdarzenia GetZdarzenia(int id);
        IEnumerable<Zdarzenia> GetAll();
        Zdarzenia AddZdarzenie(Zdarzenia zdarzenie);
        Zdarzenia UpdateZdarzenie(Zdarzenia zdarzenie);
        Zdarzenia DeleteZdarzenie(int id);
    }
}
