using KPI_vol2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPI_vol2.ViewModel
{
    public class FirstCommentVM
    {
        //comments
        public int Id { get; set; }
        public int? AttachedToTaskId { get; set; }
        public Zgloszenie? AttachedToTask { get; set; }
        public string? CommentedById { get; set; }
        public AppUser? CommentedBy { get; set; }
        public DateTime CommentedOn { get; set; }
        public string? Comment { get; set; }

        //zgloszenieVM
        public DateTime PostDate { get; set; }
        public string? UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public AppUser? PostedBy { get; set; }//

        //public string? PosterId { get; set; }//do wywalenia
        public int? CategoryId { get; set; }
        public Categories? Category { get; set; }//
        public string? Topic { get; set; }
        public int? DepartmentId { get; set; }
        public Departments? Department { get; set; }//
        public string? AssignedToId { get; set; }
        [ForeignKey(nameof(AssignedToId))]
        public AppUser? AssignedTo { get; set; }//
        public int? PriorityId { get; set; }
        public Priorities? Priority { get; set; }//
        public DateTime Deadline { get; set; }


        public DateTime? ClosedOn { get; set; }

        public int? WorkingAreaId { get; set; }
        public WorkingAreas? WorkingArea { get; set; }//

        public ICollection<Comments>? Comments { get; set; }




        public int? StatusByAssigned_Id { get; set; }//
        [ForeignKey(nameof(StatusByAssigned_Id))]//
        //[InverseProperty("Status_By_Assigned")]
        public Status? StatusByAssigned { get; set; }////




        public int? StatusByPoster_Id { get; set; }

        [ForeignKey(nameof(StatusByPoster_Id))]
        //[InverseProperty("Status_By_Poster")]
        public Status? Status { get; set; }
    }
}
