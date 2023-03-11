using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoDeviceType:IDeviceType
    {
        private readonly ApplicationDbContext _db;
        public RepoDeviceType(ApplicationDbContext db)
        {
            _db = db;
        }

        public DeviceType AddDeviceType(DeviceType DeviceType)
        {
            _db.DeviceTypes.Add(DeviceType);
            _db.SaveChanges();
            return DeviceType;
        }

        public void DeleteDeviceType(int id)
        {
            DeviceType DeviceType = _db.DeviceTypes.Find(id);
            _db.DeviceTypes.Remove(DeviceType);
            _db.SaveChanges();
        }

        public IEnumerable<DeviceType> GetAllDeviceType()
        {
            return _db.DeviceTypes.ToList();
        }

        public DeviceType GetDeviceType(int id)
        {
            return _db.DeviceTypes.Find(id);
        }

        public List<DeviceType> DeviceTypeList()
        {
            var stat = (from DeviceType in _db.DeviceTypes select DeviceType).ToList();
            return stat;
        }

        public DeviceType UpdateDeviceType(DeviceType DeviceType)
        {
            var stat = _db.DeviceTypes.Attach(DeviceType);
            stat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return DeviceType;
        }
    }
}

