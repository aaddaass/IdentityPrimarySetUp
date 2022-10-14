using KPI_vol2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace KPI_vol2.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public  virtual DbSet <Uzytkownik> Uzytkowniks { get; set; }
        public  virtual DbSet <Zdarzenia> Zdarzenia { get; set; }
        public  virtual DbSet <Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
               


            base.OnModelCreating(builder);
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            // zablokowanie usuwania powizanych danych

           
                   
                


        }
    }
}