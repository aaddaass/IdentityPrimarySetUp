//using KPI_vol2.Data;
//using KPI_vol2.Interface;
//using KPI_vol2.Models;

//namespace KPI_vol2.Repository
//{
//    public class RepoAssignerStatus:IAssignerStatus
//    {
//        private readonly ApplicationDbContext _db;
//        public RepoAssignerStatus(ApplicationDbContext db)
//        {
//            _db = db;
//        }

//        public AssignerStatus AddAssignerStatus(AssignerStatus AssignerStatus)
//        {
//            _db.AssignerStatus.Add(AssignerStatus);
//            _db.SaveChanges();
//            return AssignerStatus;
//        }

//        public void DeleteAssignerStatus(int id)
//        {
//            AssignerStatus AssignerStatus = _db.AssignerStatus.Find(id);
//            _db.AssignerStatus.Remove(AssignerStatus);
//            _db.SaveChanges();
//        }

//        public IEnumerable<AssignerStatus> GetAllAssignerStatus()
//        {
//            return _db.AssignerStatus.ToList();
//        }

//        public AssignerStatus GetAssignerStatus(int id)
//        {
//            return _db.AssignerStatus.Find(id);
//        }

//        public List<AssignerStatus> AssignerStatusList()
//        {
//            var stat = (from AssignerStatus in _db.AssignerStatus select AssignerStatus).ToList();
//            return stat;
//        }

//        public AssignerStatus UpdateAssignerStatus(AssignerStatus AssignerStatus)
//        {
//            var stat = _db.AssignerStatus.Attach(AssignerStatus);
//            stat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            _db.SaveChanges();
//            return AssignerStatus;
//        }
//    }
//}

