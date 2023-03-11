using KPI_vol2.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KPI_vol2.ViewModel
{
    public class RegisterVM
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        //public string FullName { get { return Imię + " " + Nazwisko; } }
        public int DepatmentID { get; set; }
        public Departments? Departments { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło.")]
        [Compare("Password",
            ErrorMessage = "Hasła nie sa jednakowe.")]
        public string ConfirmPassword { get; set; }
    }
}
