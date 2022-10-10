using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoUzytkownik : IUzytkownik
    {
        private readonly ApplicationDbContext _context;
        public RepoUzytkownik(ApplicationDbContext context)
        {
            _context = context;
        }
        public Uzytkownik AddUzytkownik(Uzytkownik uzytkownik)
        {
            _context.Uzytkowniks.Add(uzytkownik);
            _context.SaveChanges();
            return uzytkownik;
        }

        public Uzytkownik DeleteUzytkownik(int id)
        {
            Uzytkownik uzytkownik = _context.Uzytkowniks.Find(id);
            if (uzytkownik != null)
            {
                _context.Uzytkowniks.Remove(uzytkownik);
                _context.SaveChanges();
            }
            return uzytkownik;
        }

        public IEnumerable<Uzytkownik> GetAll()
        {
            return _context.Uzytkowniks;
        }

        public Uzytkownik GetUzytkownik(int id)
        {
            return _context.Uzytkowniks.Find(id);
        }

        public Uzytkownik UpdateUzytkownik(Uzytkownik uzytkownik)
        {
            var pracownik = _context.Uzytkowniks.Attach(uzytkownik);
            pracownik.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return uzytkownik;
        }
    }
}
