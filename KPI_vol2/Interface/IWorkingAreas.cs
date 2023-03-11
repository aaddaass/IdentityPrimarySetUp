using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IWorkingAreas
    {
        WorkingAreas GetWorkingAreas(int id);
        IEnumerable<WorkingAreas> GetAllWorkingAreas();
        WorkingAreas AddWorkingAreas(WorkingAreas  workingAreas);
        WorkingAreas UpdateWorkingAreas(WorkingAreas workingAreas);
        void DeleteWorkingAreas(int id);
        List<WorkingAreas> WorkingAreasList();
    }
}
