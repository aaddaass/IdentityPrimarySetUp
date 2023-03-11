using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoComments : IComments
    {
        private readonly ApplicationDbContext _db;
        public RepoComments(ApplicationDbContext db)
        {
            _db = db;
        }
        public Comments AddComments(Comments Comments)
        {
            _db.Comments.Add(Comments);
            _db.SaveChanges();
            return Comments;
        }

        public List<Comments> CommentsList()
        {
            var com=(from Comments in _db.Comments select Comments).ToList();
            return com;
        }

        public void DeleteComments(int id)
        {
            Comments comments = _db.Comments.Find(id);
            _db.Comments.Remove(comments);
            _db.SaveChanges();
        }

        public IEnumerable<Comments> GetAllComments()
        {
            return _db.Comments.ToList();
        }

        public Comments GetComments(int id)
        {
            return _db.Comments.Find(id);
        }

        public Comments UpdateComments(Comments Comments)
        {
            var com=_db.Comments.Attach(Comments);
            com.State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return Comments;
        }
    }
}
