using System.ComponentModel.DataAnnotations;
namespace KPI_vol2.Models
{
    public class TelephonNo
    {
        [Key]
        public int Id { get; set; }
        public string? NumerTel { get; set; }
        public string? PUK { get; set; }
        public ICollection<Uzytkownik>? Uzytkownik { get; set; }
    }
}
