using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IStatus
    {
        Status GetStatus(int id);
        IEnumerable<Status> GetAllStatus();
        Status AddStatus(Status status);
        Status UpdateStatus(Status status);
        void DeleteStatus(int id);
        List<Status> StatusList();
    }
}
