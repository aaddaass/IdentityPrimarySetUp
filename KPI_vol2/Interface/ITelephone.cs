using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface ITelephone
    {
        TelephonNo GetTelephonNo(int id);
        IEnumerable<TelephonNo> GetAllTelephonNo();
        TelephonNo AddTelephonNo(TelephonNo TelephonNo);
        TelephonNo UpdateTelephonNo(TelephonNo TelephonNo);
        void DeleteTelephonNo(int id);
        List<TelephonNo> TelephonNoList();
    }
}
