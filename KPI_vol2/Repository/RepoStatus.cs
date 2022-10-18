using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoStatus : IStatus
    {
        private readonly ApplicationDbContext _context;
        public RepoStatus(ApplicationDbContext context)
        {
            _context = context;
        }

        public Status AddStatus(Status Status)
        {
            _context.Status.Add(Status);
            _context.SaveChanges();
            return Status;
        }

        public Status DeleteStatus(int id)
        {
            Status status = _context.Status.Find(id);
            if (status != null)
            {
                _context.Status.Remove(status);
                _context.SaveChanges();
            }
            return status;
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Status;
        }

        public Status GetStatus(int id)
        {
            return _context.Status.Find(id);
        }

        public Status UpdateStatus(Status Status)
        {
            var stat= _context.Status.Attach(Status);
            stat.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Status;
        }
    }
}
