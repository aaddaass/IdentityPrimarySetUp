using KPI_vol2.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPI_vol2.ViewModel
{
    public class ZdarzenieVM
    {
        public int Id { get;set; }
        public string Name { get; set; }
        public string Opis { get; set; }
        public string Naprawa { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataZdarzenia { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataWykonania { get; set; }
        public string? OsobaOdpowiedzialna { get; set; }
        public int  IdStatus { get; set; }
        public Status? Status { get; set; }
    }
}
