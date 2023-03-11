using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPI_vol2.Models
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }
        public string NameStatus { get; set; }

        public  ICollection<Zdarzenia>? Zdarzenias { get; set; }
        //[InverseProperty("StatusByAssigned")]
        public  ICollection<Zgloszenie>? Tasks { get; set; }
        //public  ICollection<Task>? Status_By_Poster { get; set; }
        //public  ICollection<Task>? StatusByPoster { get; set; }

    }
}
