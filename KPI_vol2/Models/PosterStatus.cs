namespace KPI_vol2.Models
{
    public class PosterStatus
    {
        /*
         * Nowe
         * W trakcie
         * Zrealizowane
         * Zatrzymane
         * Anulowane
         */
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection <Tasks>? PostedTasks { get; set; }

    }
}
