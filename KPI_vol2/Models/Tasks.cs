//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace KPI_vol2.Models
//{
    
//    public class Tasks
//    {

//        [Key]
//        public int Id { get; set; }
//        public DateTime PostDate { get; set; }
//        public string UserID { get; set; }
//        [ForeignKey(nameof(UserID))]
//        public AppUser? PostedBy { get; set; }

//        //public string? PosterId { get; set; }//do wywalenia
//        public int? CategoryId { get; set; }
//        public Categories? Category { get; set; }
//        public string? Topic { get; set; }
//        public int? DepartmentId { get; set; }
//        public Departments? Department { get; set; }
//        public string? AssignedToId { get; set; }
//        [ForeignKey(nameof(AssignedToId))]
//        public AppUser? AssignedTo { get; set; }
//        public int? PriorityId { get; set; }
//        public Priorities? Priority { get; set; }
//        public DateTime Deadline { get; set; }


//        public DateTime? ClosedOn { get; set; }

//        public int? WorkingAreaId { get; set; }
//        public WorkingAreas? WorkingArea { get; set; }
        
//        public ICollection<Comments>? Comments { get; set; }




//        public int? StatusByAssigned_Id { get; set; }//do wywalenia
//        [ForeignKey(nameof(StatusByAssigned_Id))]//do wywalenia
//        //[InverseProperty("Status_By_Assigned")]
//        public Status? StatusByAssigned { get; set; }//do wywalenia




//        public int? StatusByPoster_Id { get; set; }

//        [ForeignKey(nameof(StatusByPoster_Id))]
//        //[InverseProperty("Status_By_Poster")]
//        public Status? Status { get; set; }



//        //    public  int StatusPosterID { get; set; }

//        //    [ForeignKey(nameof(StatusPosterID))]
//        //    public Status? Status { get; set; }
//    }
//}
