using System.ComponentModel.DataAnnotations;

namespace KPI_vol2.Models
{
    public class Zdarzenia
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Opis { get; set; }
        public string Naprawa { get;set; }
        public DateTime DataZdarzenia { get;set;}
        public DateTime DataWykonania { get;set; }
        public string OsobaOdpowiedzialna { get;set; }
    }
}
