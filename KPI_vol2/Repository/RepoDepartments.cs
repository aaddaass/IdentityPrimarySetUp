using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoDepartments:IDepartaments
    {
        private readonly ApplicationDbContext _db;
        public RepoDepartments(ApplicationDbContext db)
        {
            _db = db;
        }

        public Departments AddDepartments(Departments Departments)
        {
            _db.Departments.Add(Departments);
            _db.SaveChanges();
            return Departments;
        }

        public void DeleteDepartments(int id)
        {
            Departments Departments = _db.Departments.Find(id);
            _db.Departments.Remove(Departments);
            _db.SaveChanges();
        }

        public IEnumerable<Departments> GetAllDepartments()
        {
            return _db.Departments.ToList();
        }

        public Departments GetDepartments(int id)
        {
            return _db.Departments.Find(id);
        }

        public List<Departments> DepartmentsList()
        {
            var stat = (from Departments in _db.Departments select Departments).ToList();
            return stat;
        }

        public Departments UpdateDepartments(Departments Departments)
        {
            var stat = _db.Departments.Attach(Departments);
            stat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return Departments;
        }
    }
}

