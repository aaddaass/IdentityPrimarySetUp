using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;
using Microsoft.EntityFrameworkCore;

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
            var zdarzenie = _context.Zdarzenia
                            .Include(s => s.CurentStatus)
                            .OrderByDescending(d => d.DataZdarzenia)
                            .AsNoTracking();
            return zdarzenie;
           
        }

        public Zdarzenia GetZdarzenia(int id)
        {
            var zdarzenie = _context.Zdarzenia
                .Include(_ => _.CurentStatus)
                .FirstOrDefault(m=>m.Id == id);
            return zdarzenie;
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
