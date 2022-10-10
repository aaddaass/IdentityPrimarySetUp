using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KPI_vol2.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email jest wymagany!")]
        [EmailAddress]
        
        public string Email { get; set; }

        [Required(ErrorMessage ="Hasło jest wymagane!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
