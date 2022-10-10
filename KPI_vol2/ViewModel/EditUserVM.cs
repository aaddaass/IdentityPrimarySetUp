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

        public string City { get; set; }

        

        public IList<string> Roles { get; set; }
    }
}
