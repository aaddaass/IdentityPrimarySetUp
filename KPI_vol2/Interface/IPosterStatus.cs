using KPI_vol2.Models;

namespace KPI_vol2.Interface
{
    public interface IPosterStatus
    {
        PosterStatus GetPosterStatus(int id);
        IEnumerable<PosterStatus> GetAllPosterStatus();
        PosterStatus AddPosterStatus(PosterStatus  posterStatus);
        PosterStatus UpdatePosterStatus(PosterStatus posterStatus);
        void DeletePosterStatus(int id);
    }
}
