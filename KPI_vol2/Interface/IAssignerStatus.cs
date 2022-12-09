using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IAssignerStatus
    {
        AssignerStatus GetAssignerStatus(int id);
        IEnumerable<AssignerStatus> GetAllAssignerStatus();
        AssignerStatus AddAssignerStatus(AssignerStatus assigner);
        AssignerStatus UpdateAssignerStatus(AssignerStatus assigner);
        void DeleteAssignerStatus(int id);
    }
}
