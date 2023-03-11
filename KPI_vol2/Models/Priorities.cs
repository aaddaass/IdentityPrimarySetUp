namespace KPI_vol2.Models
{
    public class Priorities
    {
        /*
         * A
         * B
         * C
         */
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Tasks>? Tasks { get; set; }

    }
}
