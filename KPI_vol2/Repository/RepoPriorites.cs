using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoPriorities:IPriorities
    {
        private readonly ApplicationDbContext _db;
        public RepoPriorities(ApplicationDbContext db)
        {
            _db = db;
        }

        public Priorities AddPriorities(Priorities Priorities)
        {
            _db.Priorities.Add(Priorities);
            _db.SaveChanges();
            return Priorities;
        }

        public void DeletePriorities(int id)
        {
            Priorities Priorities = _db.Priorities.Find(id);
            _db.Priorities.Remove(Priorities);
            _db.SaveChanges();
        }

        public IEnumerable<Priorities> GetAllPriorities()
        {
            return _db.Priorities.ToList();
        }

        public Priorities GetPriorities(int id)
        {
            return _db.Priorities.Find(id);
        }

        public List<Priorities> PrioritiesList()
        {
            var stat = (from Priorities in _db.Priorities select Priorities).ToList();
            return stat;
        }

        public Priorities UpdatePriorities(Priorities Priorities)
        {
            var stat = _db.Priorities.Attach(Priorities);
            stat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return Priorities;
        }
    }
}

