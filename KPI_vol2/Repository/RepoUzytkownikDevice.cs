using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;
using Microsoft.EntityFrameworkCore;

namespace KPI_vol2.Repository
{
    public class RepoUzytkownikDevice : IUrzyt_Device
    {
        private readonly ApplicationDbContext _db;
        public RepoUzytkownikDevice(ApplicationDbContext db)
        {
            _db = db;
        }

        public UzytkownikDevice AddUzytkownikDevice(UzytkownikDevice uzytkownikDevice)
        {
            _db.UzytkownikDevices.Add(uzytkownikDevice);
            _db.SaveChanges();
            return uzytkownikDevice;
        }

        public void DeleteUzytkownikDevice(int id)
        {
            UzytkownikDevice uzytkownikDevice = _db.UzytkownikDevices.Find(id);
            _db.UzytkownikDevices.Remove(uzytkownikDevice);
            _db.SaveChanges();
        }

        public IEnumerable<UzytkownikDevice> GetAllUzytkownikDevice()
        {
            var uzytdev = _db.UzytkownikDevices
                         .Include(u => u.Uzytkownik)
                         .Include(d => d.Device)
                         .AsNoTracking();
            return uzytdev;
        }

        public UzytkownikDevice GetUzytkownikDevice(int id)
        {
            var uzytdev = _db.UzytkownikDevices
                .Include(_ => _.Uzytkownik)
                .Include(_ => _.Device)
                .FirstOrDefault();
            return uzytdev;
        }

        public UzytkownikDevice UpdateUzytkownikDevice(UzytkownikDevice uzytkownikDevice)
        {
            var uzytdev = _db.UzytkownikDevices.Attach(uzytkownikDevice);
            uzytdev.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return uzytkownikDevice;
        }
    }
}
