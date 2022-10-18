using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IStatus
    {
        Status GetStatus(int id);
        IEnumerable<Status> GetAll();
        Status AddStatus(Status Status);
        Status UpdateStatus(Status Status);
        Status DeleteStatus(int id);


    }
}
