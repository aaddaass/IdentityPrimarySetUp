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

        public  DbSet <Uzytkownik> Uzytkowniks { get; set; }
        public  DbSet <Zdarzenia> Zdarzenia { get; set; }
        public  DbSet <Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.Entity<Status>()
                .HasMany(s => s.Zdarzenias)
                .WithOne(s => s.Status)
                .HasForeignKey(s=>s.Id);

            builder.Entity<Zdarzenia>()
                .HasOne(s => s.Status)
                .WithMany(z => z.Zdarzenias)
                .HasForeignKey(c=>c.CurentStatusId);
            //poodczas tworzenia relacji jeden do wielu  trzeba zdeklarować klucz obcy w tabeli rodzica!! 
        }
    }
}