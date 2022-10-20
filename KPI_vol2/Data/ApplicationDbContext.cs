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

        public   DbSet <Uzytkownik> Uzytkowniks { get; set; }
        public    DbSet <Zdarzenia> Zdarzenia { get; set; }
        public   DbSet <Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
               


            base.OnModelCreating(builder);
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            // zablokowanie usuwania powizanych danych

            builder.Entity<Status>()
                .HasMany(z => z.Zdarzenia)
                .WithOne(s => s.CurentStatus);
            builder.Entity<Zdarzenia>()
                .HasOne(s => s.CurentStatus)
                .WithMany(z => z.Zdarzenia);
            
                
                


           
                   
                


        }
    }
}