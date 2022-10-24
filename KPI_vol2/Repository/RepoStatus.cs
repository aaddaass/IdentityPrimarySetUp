using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoStatus : IStatus
    {
        private readonly ApplicationDbContext _db;
        public RepoStatus(ApplicationDbContext db)
        {
            _db = db;
        }

        public Status AddStatus(Status status)
        {
            _db.Status.Add(status);
            _db.SaveChanges();
            return status;
        }

        public void DeleteStatus(int id)
        {
            Status status = _db.Status.Find(id);
            _db.Status.Remove(status);
            _db.SaveChanges();
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return _db.Status;
        }

        public Status GetStatus(int id)
        {
            return _db.Status.Find(id);
        }

        public List<Status> StatusList()
        {
            var stat = (from Status in _db.Status select Status).ToList();
            return stat;
        }

        public Status UpdateStatus(Status status)
        {
            var stat=_db.Status.Attach(status);
            stat.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return status;
        }
    }
}
