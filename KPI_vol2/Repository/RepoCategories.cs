using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;

namespace KPI_vol2.Repository
{
    public class RepoCategories:ICategories
    {
        private readonly ApplicationDbContext _db;
        public RepoCategories(ApplicationDbContext db)
        {
            _db = db;
        }

        public Categories AddCategories(Categories Categories)
        {
            _db.Categories.Add(Categories);
            _db.SaveChanges();
            return Categories;
        }

        public void DeleteCategories(int id)
        {
            Categories Categories = _db.Categories.Find(id);
            _db.Categories.Remove(Categories);
            _db.SaveChanges();
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public Categories GetCategories(int id)
        {
            return _db.Categories.Find(id);
        }

        public List<Categories> CategoriesList()
        {
            var stat = (from Categories in _db.Categories select Categories).ToList();
            return stat;
        }

        public Categories UpdateCategories(Categories Categories)
        {
            var stat = _db.Categories.Attach(Categories);
            stat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return Categories;
        }
    }
}

