using Microsoft.AspNetCore.Identity;

namespace KPI_vol2.Models
{
    public class AppUser:IdentityUser
    {
        public ICollection<Tasks>? PostedTasks { get; set; }
        public ICollection<Tasks>? AssignedTasks { get; set; }

        public ICollection<Comments>? Comments { get; set; }
    }
}
