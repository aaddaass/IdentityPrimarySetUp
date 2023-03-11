using Microsoft.AspNetCore.Identity;
using System.Security.Policy;

namespace KPI_vol2.Models
{
    public class AppUser:IdentityUser
    {
        //public string Id { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string FullName { get { return Imie + " " + Nazwisko; } }
        public int DepatmentID { get; set; }
        public Departments? Departments { get; set; }
        //public ICollection<Tasks>? PostedTasks { get; set; }
        //public ICollection<Tasks>? AssignedTasks { get; set; }
        public ICollection<Zgloszenie>? Zdarzenias_k { get; set; }

        public ICollection<Comments>? Comments { get; set; }
    }
}
