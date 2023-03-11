using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoTelephonNo:ITelephone
    {
        private readonly ApplicationDbContext _db;
        public RepoTelephonNo(ApplicationDbContext db)
        {
            _db = db;
        }

        public TelephonNo AddTelephonNo(TelephonNo TelephonNo)
        {
            _db.TelephonNos.Add(TelephonNo);
            _db.SaveChanges();
            return TelephonNo;
        }

        public void DeleteTelephonNo(int id)
        {
            TelephonNo TelephonNo = _db.TelephonNos.Find(id);
            _db.TelephonNos.Remove(TelephonNo);
            _db.SaveChanges();
        }

        public IEnumerable<TelephonNo> GetAllTelephonNo()
        {
            return _db.TelephonNos.ToList();
        }

        public TelephonNo GetTelephonNo(int id)
        {
            return _db.TelephonNos.Find(id);
        }

        public List<TelephonNo> TelephonNoList()
        {
            var stat = (from TelephonNo in _db.TelephonNos select TelephonNo).ToList();
            return stat;
        }

        public TelephonNo UpdateTelephonNo(TelephonNo TelephonNo)
        {
            var stat = _db.TelephonNos.Attach(TelephonNo);
            stat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return TelephonNo;
        }
    }
}

