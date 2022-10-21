using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoZdarzenia : IZdarzenia
    {
        private readonly ApplicationDbContext _db;
        public RepoZdarzenia(ApplicationDbContext db)
        {
            _db = db;
        }

        public Zdarzenia AddZdarzenia(Zdarzenia zdarzenia)
        {
            _db.Zdarzenia.Add(zdarzenia);
            _db.SaveChanges();
            return zdarzenia;
        }

        public void DeleteZdarzenia(int id)
        {
            Zdarzenia zdarzenia = _db.Zdarzenia.Find(id);
            _db.Zdarzenia.Remove(zdarzenia);
            _db.SaveChanges();
        }

        public Zdarzenia GetZdarzenia(int id)
        {
            return _db.Zdarzenia.Find(id);
        }

        public IEnumerable<Zdarzenia> GetAllZdarzenia()
        {
            return _db.Zdarzenia;
        }

        public Zdarzenia UpdateZdarzenia(Zdarzenia zdarzenia)
        {
            var zgloszenie = _db.Zdarzenia.Attach(zdarzenia);
            zgloszenie.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return zdarzenia;
        }
    }
}
