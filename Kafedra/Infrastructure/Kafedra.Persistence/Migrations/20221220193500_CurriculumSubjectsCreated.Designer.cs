﻿// <auto-generated />
using System;
using Kafedra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kafedra.Persistence.Migrations
{
    [DbContext(typeof(KafedraContext))]
    [Migration("20221220193500_CurriculumSubjectsCreated")]
    partial class CurriculumSubjectsCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kafedra.Domain.Entities.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Curriculum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Curriculums");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.CurriculumSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurriculumId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CurriculumSubjects");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Dissertation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("FromBachalavr")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Dissertations");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Partners", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurriculumId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.SubjectQualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("QualificationId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QualificationId");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectQualifications");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Syllabus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("AppUserId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId1");

                    b.ToTable("Syllabuss");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.UserDissertation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DissertationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("DissertationId");

                    b.ToTable("UserDissertations");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.UserSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SubejectID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("SubjectId");

                    b.ToTable("UserSubjects");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
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

            modelBuilder.Entity("Kafedra.Domain.Identities.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FromAztu")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DepartmentId");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.CurriculumSubject", b =>
                {
                    b.HasOne("Kafedra.Domain.Entities.Curriculum", "Curriculum")
                        .WithMany()
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kafedra.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curriculum");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Qualification", b =>
                {
                    b.HasOne("Kafedra.Domain.Entities.Faculty", "Faculty")
                        .WithMany("Qualifications")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.SubjectQualification", b =>
                {
                    b.HasOne("Kafedra.Domain.Entities.Qualification", "Qualification")
                        .WithMany("UserSubjects")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kafedra.Domain.Entities.Subject", "Subject")
                        .WithMany("SubjectQualifications")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Qualification");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Syllabus", b =>
                {
                    b.HasOne("Kafedra.Domain.Identities.AppUser", "AppUser")
                        .WithMany("Syllabus")
                        .HasForeignKey("AppUserId1");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.UserDissertation", b =>
                {
                    b.HasOne("Kafedra.Domain.Identities.AppUser", "AppUser")
                        .WithMany("UserDissertations")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kafedra.Domain.Entities.Dissertation", "Dissertation")
                        .WithMany("UserDissertations")
                        .HasForeignKey("DissertationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Dissertation");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.UserSubject", b =>
                {
                    b.HasOne("Kafedra.Domain.Identities.AppUser", "AppUser")
                        .WithMany("UserSubjects")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kafedra.Domain.Entities.Subject", "Subject")
                        .WithMany("UserSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kafedra.Domain.Identities.AppUser", b =>
                {
                    b.HasOne("Kafedra.Domain.Entities.Department", "Department")
                        .WithMany("AppUsers")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Department", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Dissertation", b =>
                {
                    b.Navigation("UserDissertations");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Faculty", b =>
                {
                    b.Navigation("Qualifications");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Qualification", b =>
                {
                    b.Navigation("UserSubjects");
                });

            modelBuilder.Entity("Kafedra.Domain.Entities.Subject", b =>
                {
                    b.Navigation("SubjectQualifications");

                    b.Navigation("UserSubjects");
                });

            modelBuilder.Entity("Kafedra.Domain.Identities.AppUser", b =>
                {
                    b.Navigation("Syllabus");

                    b.Navigation("UserDissertations");

                    b.Navigation("UserSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
