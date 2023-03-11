﻿// <auto-generated />
using System;
using KPI_vol2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KPI_vol2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221227082045_fullname")]
    partial class fullname
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KPI_vol2.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("KPI_vol2.Models.AssignerStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssignerStatus");
                });

            modelBuilder.Entity("KPI_vol2.Models.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("KPI_vol2.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AttachedToTaskId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CommentedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AttachedToTaskId");

                    b.HasIndex("CommentedById");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("KPI_vol2.Models.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("KPI_vol2.Models.Device", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("DomainName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IMEI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("KPI_vol2.Models.DeviceType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NazwaUrzadzenia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("KPI_vol2.Models.PosterStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PosterStatus");
                });

            modelBuilder.Entity("KPI_vol2.Models.Priorities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("KPI_vol2.Models.Status", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatus"), 1L, 1);

                    b.Property<string>("NameStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStatus");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("KPI_vol2.Models.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AssignedToId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ClosedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PosterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PriorityId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusByAssignedId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusByPosterId")
                        .HasColumnType("int");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkingAreaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PosterId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("StatusByAssignedId");

                    b.HasIndex("StatusByPosterId");

                    b.HasIndex("WorkingAreaId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("KPI_vol2.Models.TelephonNo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NumerTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PUK")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TelephonNos");
                });

            modelBuilder.Entity("KPI_vol2.Models.Uzytkownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imię")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TelefonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("TelefonId");

                    b.ToTable("Uzytkowniks");
                });

            modelBuilder.Entity("KPI_vol2.Models.UzytkownikDevice", b =>
                {
                    b.Property<int>("DeviceID")
                        .HasColumnType("int");

                    b.Property<int>("UzytkownikID")
                        .HasColumnType("int");

                    b.HasKey("DeviceID", "UzytkownikID");

                    b.HasIndex("UzytkownikID");

                    b.ToTable("UzytkownikDevices");
                });

            modelBuilder.Entity("KPI_vol2.Models.WorkingAreas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkingAreas");
                });

            modelBuilder.Entity("KPI_vol2.Models.Zdarzenia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CurentStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataWykonania")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataZdarzenia")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naprawa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OsobaOdpowiedzialna")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurentStatusId");

                    b.ToTable("Zdarzenia");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("KPI_vol2.Models.Comments", b =>
                {
                    b.HasOne("KPI_vol2.Models.Tasks", "AttachedToTask")
                        .WithMany("Comments")
                        .HasForeignKey("AttachedToTaskId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KPI_vol2.Models.AppUser", "CommentedBy")
                        .WithMany("Comments")
                        .HasForeignKey("CommentedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AttachedToTask");

                    b.Navigation("CommentedBy");
                });

            modelBuilder.Entity("KPI_vol2.Models.Device", b =>
                {
                    b.HasOne("KPI_vol2.Models.DeviceType", "DeviceType")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DeviceType");
                });

            modelBuilder.Entity("KPI_vol2.Models.Tasks", b =>
                {
                    b.HasOne("KPI_vol2.Models.AppUser", "AssignedTo")
                        .WithMany("AssignedTasks")
                        .HasForeignKey("AssignedToId");

                    b.HasOne("KPI_vol2.Models.Categories", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KPI_vol2.Models.Departments", "Department")
                        .WithMany("Tasks")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KPI_vol2.Models.AppUser", "PostedBy")
                        .WithMany("PostedTasks")
                        .HasForeignKey("PosterId");

                    b.HasOne("KPI_vol2.Models.Priorities", "Priority")
                        .WithMany("Tasks")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KPI_vol2.Models.AssignerStatus", "StatusByAssigned")
                        .WithMany("AssignedTasks")
                        .HasForeignKey("StatusByAssignedId");

                    b.HasOne("KPI_vol2.Models.PosterStatus", "StatusByPoster")
                        .WithMany("PostedTasks")
                        .HasForeignKey("StatusByPosterId");

                    b.HasOne("KPI_vol2.Models.WorkingAreas", "WorkingArea")
                        .WithMany("Tasks")
                        .HasForeignKey("WorkingAreaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AssignedTo");

                    b.Navigation("Category");

                    b.Navigation("Department");

                    b.Navigation("PostedBy");

                    b.Navigation("Priority");

                    b.Navigation("StatusByAssigned");

                    b.Navigation("StatusByPoster");

                    b.Navigation("WorkingArea");
                });

            modelBuilder.Entity("KPI_vol2.Models.Uzytkownik", b =>
                {
                    b.HasOne("KPI_vol2.Models.Departments", "Departments")
                        .WithMany("User")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KPI_vol2.Models.TelephonNo", "TelephonNo")
                        .WithMany("Uzytkownik")
                        .HasForeignKey("TelefonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Departments");

                    b.Navigation("TelephonNo");
                });

            modelBuilder.Entity("KPI_vol2.Models.UzytkownikDevice", b =>
                {
                    b.HasOne("KPI_vol2.Models.Device", "Device")
                        .WithMany("uzytkownikDevices")
                        .HasForeignKey("DeviceID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KPI_vol2.Models.Uzytkownik", "Uzytkownik")
                        .WithMany("uzytkownikDevices")
                        .HasForeignKey("UzytkownikID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Uzytkownik");
                });

            modelBuilder.Entity("KPI_vol2.Models.Zdarzenia", b =>
                {
                    b.HasOne("KPI_vol2.Models.Status", "Status")
                        .WithMany("Zdarzenias")
                        .HasForeignKey("CurentStatusId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KPI_vol2.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KPI_vol2.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KPI_vol2.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("KPI_vol2.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("KPI_vol2.Models.AppUser", b =>
                {
                    b.Navigation("AssignedTasks");

                    b.Navigation("Comments");

                    b.Navigation("PostedTasks");
                });

            modelBuilder.Entity("KPI_vol2.Models.AssignerStatus", b =>
                {
                    b.Navigation("AssignedTasks");
                });

            modelBuilder.Entity("KPI_vol2.Models.Categories", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("KPI_vol2.Models.Departments", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KPI_vol2.Models.Device", b =>
                {
                    b.Navigation("uzytkownikDevices");
                });

            modelBuilder.Entity("KPI_vol2.Models.DeviceType", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("KPI_vol2.Models.PosterStatus", b =>
                {
                    b.Navigation("PostedTasks");
                });

            modelBuilder.Entity("KPI_vol2.Models.Priorities", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("KPI_vol2.Models.Status", b =>
                {
                    b.Navigation("Zdarzenias");
                });

            modelBuilder.Entity("KPI_vol2.Models.Tasks", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("KPI_vol2.Models.TelephonNo", b =>
                {
                    b.Navigation("Uzytkownik");
                });

            modelBuilder.Entity("KPI_vol2.Models.Uzytkownik", b =>
                {
                    b.Navigation("uzytkownikDevices");
                });

            modelBuilder.Entity("KPI_vol2.Models.WorkingAreas", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
