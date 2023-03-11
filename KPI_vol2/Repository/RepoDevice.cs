using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoDevice:IDevice
    {
        private readonly ApplicationDbContext _db;
        public RepoDevice(ApplicationDbContext db)
        {
            _db = db;
        }

        public Device AddDevice(Device Device)
        {
            _db.Devices.Add(Device);
            _db.SaveChanges();
            return Device;
        }

        public void DeleteDevice(int id)
        {
            Device Device = _db.Devices.Find(id);
            _db.Devices.Remove(Device);
            _db.SaveChanges();
        }

        public IEnumerable<Device> GetAllDevice()
        {
            return _db.Devices.ToList();
        }

        public Device GetDevice(int id)
        {
            return _db.Devices.Find(id);
        }

        public List<Device> DeviceList()
        {
            var stat = (from Device in _db.Devices select Device).ToList();
            return stat;
        }

        public Device UpdateDevice(Device Device)
        {
            var stat = _db.Devices.Attach(Device);
            stat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return Device;
        }
    }
}

