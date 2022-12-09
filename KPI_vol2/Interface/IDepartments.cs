using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IDepartaments
    {
        Departments GetDepartments(int id);
        IEnumerable<Departments> GetAllDepartments();
        Departments AddDepartments(Departments  departments);
        Departments UpdateDepartments(Departments departments);
        void DeleteDepartments(int id);
    }
}
