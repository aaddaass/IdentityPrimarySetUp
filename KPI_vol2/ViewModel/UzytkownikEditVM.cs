using KPI_vol2.Models;

namespace KPI_vol2.ViewModel
{
    public class UzytkownikEditVM
    {
        public int Id { get; set; }
        public string? Imię { get; set; }
        public string? Nazwisko { get; set; }
        public string? Email { get; set; }
    
        public int? DepartmentID { get; set; }
        public Departments? Departments { get; set; }
        public int? TelefonId { get; set; }
        public TelephonNo? TelephonNo { get; set; }
    }
}
