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

        public DbSet <Tasks> Tasks { get; set; }
        public DbSet <Categories> Categories { get; set; }
        public DbSet <PosterStatus> PosterStatus { get; set; }
        public DbSet <AssignerStatus> AssignerStatus { get; set; }
        public DbSet <Comments> Comments { get; set; }
        public DbSet <Departments> Departments { get; set; }
        public DbSet <WorkingAreas> WorkingAreas { get; set; }

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
            //Task relations:
            //PostedByRelation
            builder.Entity<Tasks>()
                .HasOne(s => s.PostedBy)
                .WithMany(g => g.PostedTasks)
                .HasForeignKey(s => s.PosterId);

            //Categories
            builder.Entity<Tasks>()
                .HasOne(s => s.Category)
                .WithMany(g => g.Tasks)
                .HasForeignKey(s => s.CategoryId);
            //Departments
            builder.Entity<Tasks>()
                .HasOne(s => s.Department)
                .WithMany(g => g.Tasks)
                .HasForeignKey(s => s.DepartmentId);
            //Assigned
            builder.Entity<Tasks>()
                .HasOne(s => s.AssignedTo)
                .WithMany(g => g.AssignedTasks)
                .HasForeignKey(s => s.AssignedToId);
            //Priorites
            builder.Entity<Tasks>()
                .HasOne(s => s.Priority)
                .WithMany(g => g.Tasks)
                .HasForeignKey(s => s.PriorityId);
            //AssignedStatus
            builder.Entity<Tasks>()
                .HasOne(s => s.StatusByAssigned)
                .WithMany(g => g.AssignedTasks)
                .HasForeignKey(s => s.StatusByAssignedId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //PosterStatus
            builder.Entity<Tasks>()
                .HasOne(s => s.StatusByPoster)
                .WithMany(g => g.PostedTasks)
                .HasForeignKey(s => s.StatusByPosterId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //Working area
            builder.Entity<Tasks>()
                .HasOne(s => s.WorkingArea)
                .WithMany(g => g.Tasks)
                .HasForeignKey(s =>s.WorkingAreaId);
            //Comments
            builder.Entity<Comments>()
                .HasOne(s => s.AttachedToTask)
                .WithMany(g => g.Comments)
                .HasForeignKey(s => s.AttachedToTaskId);
            //Comment to user
            builder.Entity<Comments>()
                .HasOne(s => s.CommentedBy)
                .WithMany(g => g.Comments)
                .HasForeignKey(s => s.CommentedById);
            //poodczas tworzenia relacji jeden do wielu  trzeba zdeklarować klucz obcy w tabeli rodzica!! 
        }
    }
}