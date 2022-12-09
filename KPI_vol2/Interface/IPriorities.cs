using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IPriorities
    {
        Priorities GetPriorities(int id);
        IEnumerable<Priorities> GetAllPriorities();
        Priorities AddPriorities(Priorities  priorities);
        Priorities UpdatePriorities(Priorities priorities);
        void DeletePriorities(int id);
    }
}
