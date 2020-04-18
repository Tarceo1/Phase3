using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LMS.Models.LMSModels
{
    public partial class Team94LMSContext : DbContext
    {
        public Team94LMSContext()
        {
        }

        public Team94LMSContext(DbContextOptions<Team94LMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<AssignmentCatagories> AssignmentCatagories { get; set; }
        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Professors> Professors { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Submissions> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=atr.eng.utah.edu;User Id=u1275806;Password=DONTCARE;Database=Team94LMS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<AssignmentCatagories>(entity =>
            {
                entity.HasKey(e => e.CataId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => new { e.Class, e.Name })
                    .HasName("classID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CataId).HasColumnName("cataID");

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.AssignmentCatagories)
                    .HasForeignKey(d => d.Class)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("class");
            });

            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.HasKey(e => e.AssignId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Catagory)
                    .HasName("cataID_idx");

                entity.HasIndex(e => new { e.Name, e.Catagory })
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.AssignId).HasColumnName("assignID");

                entity.Property(e => e.Catagory).HasColumnName("catagory");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("varchar(8196)");

                entity.Property(e => e.Due)
                    .HasColumnName("due")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.HasOne(d => d.CatagoryNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.Catagory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cataID");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Course)
                    .HasName("courseID_idx");

                entity.HasIndex(e => e.Prof)
                    .HasName("teacher_idx");

                entity.HasIndex(e => new { e.Course, e.Year, e.Semester })
                    .HasName("classUQ_idx")
                    .IsUnique();

                entity.Property(e => e.ClassId).HasColumnName("classID");

                entity.Property(e => e.Course).HasColumnName("course");

                entity.Property(e => e.End)
                    .HasColumnName("end")
                    .HasColumnType("datetime");

                entity.Property(e => e.Loc)
                    .IsRequired()
                    .HasColumnName("loc")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Prof)
                    .IsRequired()
                    .HasColumnName("prof")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasColumnName("semester")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("datetime");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.CourseNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Course)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("courseID");

                entity.HasOne(d => d.ProfNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Prof)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teacher");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Department)
                    .HasName("subject_idx");

                entity.HasIndex(e => new { e.Number, e.Department })
                    .HasName("number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CourseId).HasColumnName("courseID");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnName("department")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subject");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.Abbr)
                    .HasName("PRIMARY");

                entity.Property(e => e.Abbr)
                    .HasColumnName("abbr")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.Student, e.Class })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Class)
                    .HasName("FC_Class_idx");

                entity.Property(e => e.Student)
                    .HasColumnName("student")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnName("grade")
                    .HasColumnType("varchar(2)");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.Class)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FC_Class");

                entity.HasOne(d => d.StudentNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.Student)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FC_Student");
            });

            modelBuilder.Entity<Professors>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Department)
                    .HasName("Works In_idx");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnName("department")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Professors)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("WorksIn");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Major)
                    .HasName("MajoringIn_idx");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Major)
                    .IsRequired()
                    .HasColumnName("major")
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.MajorNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Major)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MajoringIn");
            });

            modelBuilder.Entity<Submissions>(entity =>
            {
                entity.HasKey(e => new { e.Student, e.Assignment })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Assignment)
                    .HasName("assignment_idx");

                entity.Property(e => e.Student)
                    .HasColumnName("student")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Assignment).HasColumnName("assignment");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AssignmentNavigation)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.Assignment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assignment");

                entity.HasOne(d => d.StudentNavigation)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.Student)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student");
            });
        }
    }
}
