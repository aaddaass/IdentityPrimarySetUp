using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoWorkingAreas:IWorkingAreas
    {
        private readonly ApplicationDbContext _db;
        public RepoWorkingAreas(ApplicationDbContext db)
        {
            _db = db;
        }

        public WorkingAreas AddWorkingAreas(WorkingAreas WorkingAreas)
        {
            _db.WorkingAreas.Add(WorkingAreas);
            _db.SaveChanges();
            return WorkingAreas;
        }

        public void DeleteWorkingAreas(int id)
        {
            WorkingAreas WorkingAreas = _db.WorkingAreas.Find(id);
            _db.WorkingAreas.Remove(WorkingAreas);
            _db.SaveChanges();
        }

        public IEnumerable<WorkingAreas> GetAllWorkingAreas()
        {
            return _db.WorkingAreas.ToList();
        }

        public WorkingAreas GetWorkingAreas(int id)
        {
            return _db.WorkingAreas.Find(id);
        }

        public List<WorkingAreas> WorkingAreasList()
        {
            var stat = (from WorkingAreas in _db.WorkingAreas select WorkingAreas).ToList();
            return stat;
        }

        public WorkingAreas UpdateWorkingAreas(WorkingAreas WorkingAreas)
        {
            var stat = _db.WorkingAreas.Attach(WorkingAreas);
            stat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return WorkingAreas;
        }
    }
}

