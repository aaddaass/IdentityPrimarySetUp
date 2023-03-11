using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface ICategories
    {
        Categories GetCategories(int id);
        IEnumerable<Categories> GetAllCategories();
        Categories AddCategories(Categories categories);
        Categories UpdateCategories(Categories categories);
        void DeleteCategories(int id);
        List<Categories> CategoriesList();
    }
}
