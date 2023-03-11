using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;
using Microsoft.EntityFrameworkCore;


namespace KPI_vol2.Repository
{
    public class RepoZgloszenie : IZgloszenie
    {
        private readonly ApplicationDbContext _db;
        public RepoZgloszenie(ApplicationDbContext db)
        {
            _db = db;
        }

        public Zgloszenie AddZgloszenie(Zgloszenie zgloszenie)
        {
            _db.Zgloszenies.Add(zgloszenie);
            _db.SaveChanges();
            return zgloszenie;
        }

        public void DeleteZgloszenie(int id)
        {
            Zgloszenie zgloszenie = _db.Zgloszenies.Find(id);
            _db.Zgloszenies.Remove(zgloszenie);
            _db.SaveChanges();
        }

        public IEnumerable<Zgloszenie> GetAllZgloszenie()
        {
            var zgloszenie=_db.Zgloszenies
                .Include(z=>z.PostedBy)
                .Include(z=>z.AssignedTo)
                .Include(z=>z.Category)
                //.Include(z=>z.Department)
                .Include(z=>z.Priority)
                .Include(z=>z.WorkingArea)
                .Include(z=>z.StatusByAssigned)
                .Include(z=>z.Status)
                .Include(z=>z.Comments)
                .OrderBy(z=>z.PostDate)
                .AsNoTracking();
            return zgloszenie;
        }

        //public Zgloszenie GetBHPZgloszenie(int id)
        //{
        //    var BHPid = _db.Departments
        //        .Where(z => z.Name == "BHP")
        //        .Select(z => z.Id);
            
               
                
                
        //}

        public Zgloszenie GetZgloszenie(int id)
        {
            var zgloszenie =_db.Zgloszenies
                 .Include(z => z.PostedBy)
                .Include(z => z.AssignedTo)
                .Include(z => z.Category)
                //.Include(z => z.Department)
                .Include(z => z.Priority)
                .Include(z => z.WorkingArea)
                .Include(z => z.StatusByAssigned)
                .Include(z => z.Status)
                .Include(z=>z.Comments)
                .ThenInclude(c => c.CommentedBy)

                .FirstOrDefault(i=>i.Id == id);
            return zgloszenie;

        }

        public Zgloszenie UpdateZgloszenie(Zgloszenie zgloszenie)
        {
            var zglo=_db.Zgloszenies.Attach(zgloszenie);
            zglo.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return zgloszenie;
        }
    }
}
