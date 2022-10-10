using System.ComponentModel.DataAnnotations;

namespace KPI_vol2.ViewModel
{
    public class CreateRoleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}
