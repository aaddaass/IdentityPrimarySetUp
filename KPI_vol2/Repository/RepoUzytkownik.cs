using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;
using Microsoft.EntityFrameworkCore;

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
            var uzytkownik = _context.Uzytkowniks
                            .Include(t => t.TelephonNo)
                             .Include(d=>d.Departments)
                             .Include(d=>d.uzytkownikDevices)
                             .ThenInclude(d=>d.Device)
                            .AsNoTracking();
            return uzytkownik;
        }

        public Uzytkownik GetUzytkownik(int id)
        {
            var uzytkownik=_context.Uzytkowniks
                            .Include(t=>t.TelephonNo)
                            .Include(d=>d.uzytkownikDevices)
                            
                            .ThenInclude(d=>d.Device)
                            //.ThenInclude(d=>d.DeviceType)
                            .Include(d=>d.Departments)
                            .FirstOrDefault(i=>i.Id==id);
            return uzytkownik;
        }

        public Uzytkownik UpdateUzytkownik(Uzytkownik uzytkownik)
        {
            var pracownik = _context.Uzytkowniks.Attach(uzytkownik);
            pracownik.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return uzytkownik;
        }

        public List<Uzytkownik> uzytkownikList()
        {
            var uzytkownik=(from Uzytkownik in _context.Uzytkowniks select Uzytkownik).ToList();
            return uzytkownik;
        }
    }
}
