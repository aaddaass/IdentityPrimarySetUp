using System.ComponentModel.DataAnnotations.Schema;

namespace KPI_vol2.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public DateTime PostDate { get; set; }
        public AppUser? PostedBy { get; set; }
        public string? PosterId { get; set; }
        public Categories? Category { get; set; }
        public int? CategoryId { get; set; }
        public string? Topic { get; set; }
        public Departments? Department { get; set; }
        public int? DepartmentId { get; set; }
        public AppUser? AssignedTo { get; set; }
        public string? AssignedToId { get; set; }
        public Priorities? Priority { get; set; }
        public int? PriorityId { get; set; }
        public DateTime Deadline { get; set; }

        [ForeignKey("StatusByPosterId")]
        public PosterStatus? StatusByPoster { get; set; }
        public int? StatusByPosterId { get; set; }

        [ForeignKey("StatusByAssignedId")]
        public AssignerStatus? StatusByAssigned { get; set; }
        public int? StatusByAssignedId { get; set; }
        public DateTime? ClosedOn { get; set; }

        public WorkingAreas? WorkingArea { get; set; }
        public int? WorkingAreaId { get; set; }
        
        public ICollection<Comments>? Comments { get; set; }

    }
}
