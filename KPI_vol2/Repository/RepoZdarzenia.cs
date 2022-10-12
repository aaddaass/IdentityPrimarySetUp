using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoZdarzenia : IZdarzenie
    {
        private readonly ApplicationDbContext _context;
        public RepoZdarzenia(ApplicationDbContext context)
        {
            _context = context;
        }

        public Zdarzenia AddZdarzenie(Zdarzenia zdarzenie)
        {
            _context.Zdarzenia.Add(zdarzenie);
            _context.SaveChanges();
            return zdarzenie;
        }

        public Zdarzenia DeleteZdarzenie(int id)
        {
            Zdarzenia zdarzenie=_context.Zdarzenia.Find(id);
            if(zdarzenie!=null)
            {
                _context.Zdarzenia.Remove(zdarzenie);
                _context.SaveChanges();
            }
            return zdarzenie;
        }

        public IEnumerable<Zdarzenia> GetAll()
        {
            return _context.Zdarzenia;
        }

        public Zdarzenia GetZdarzenia(int id)
        {
            return _context.Zdarzenia.Find(id);
        }

        public Zdarzenia UpdateZdarzenie(Zdarzenia zdarzenie)
        {
            var zdarz = _context.Zdarzenia.Attach(zdarzenie);
            zdarz.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return zdarzenie;
        }
    }
}
