namespace KPI_vol2.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public DateTime PostDate { get; set; }
        public int PostedBy { get; set; }
        public int Area { get; set; }
        public int Category { get; set; }
        public string? Topic { get; set; }
        public int Department { get; set; }
        public int AssignedTo { get; set; }
        public int Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int StatusByPoster { get; set; }
        public int StatusByAssigned { get; set; }
        public DateTime ClosedOn { get; set; }
        

    }
}
