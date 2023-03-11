using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IComments
    {
        Comments GetComments(int id);
        IEnumerable<Comments> GetAllComments();
        Comments AddComments(Comments Comments);
        Comments UpdateComments(Comments Comments);
        void DeleteComments(int id);
        List<Comments> CommentsList();
    }
}
