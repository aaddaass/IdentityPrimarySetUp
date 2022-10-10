using System.ComponentModel.DataAnnotations;

namespace KPI_vol2.ViewModel
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
