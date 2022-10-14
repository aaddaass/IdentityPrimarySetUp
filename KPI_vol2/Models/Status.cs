using System.ComponentModel.DataAnnotations;

namespace KPI_vol2.Models
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }
        public string Name { get; set; }
        public  ICollection <Zdarzenia> Zdarzenia { get; set; }
    }
}
