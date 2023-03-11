using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IZgloszenie
    {
        Zgloszenie GetZgloszenie(int id);
        IEnumerable<Zgloszenie> GetAllZgloszenie();
        Zgloszenie AddZgloszenie(Zgloszenie zgloszenie);
        Zgloszenie UpdateZgloszenie(Zgloszenie zgloszenie);
        void DeleteZgloszenie(int id);
        //dodać listę zgłoszeń 

        //Zgloszenie GetBHPZgloszenie(int id);
    }
}
