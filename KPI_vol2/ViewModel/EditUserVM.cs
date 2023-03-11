using KPI_vol2.Models;
using System.ComponentModel.DataAnnotations;

namespace KPI_vol2.ViewModel
{
    public class EditUserVM
    {
        public EditUserVM()
        {
            
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //public string City { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public int DepatmentID { get; set; }
        public Departments? Departments { get; set; }


        public IList<string> Roles { get; set; }
    }
}
