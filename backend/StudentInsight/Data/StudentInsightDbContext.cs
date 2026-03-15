using Microsoft.EntityFrameworkCore;
using StudentInsight.Entities;

namespace StudentInsight.Data
{
    public sealed class StudentInsightDbContext : DbContext
    {
        public StudentInsightDbContext(DbContextOptions<StudentInsightDbContext> options) : base(options) { }

        /*/ <----- DbSets -----> /*/
        public DbSet<User> Users => Set<User>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<StudentExamLogs> StudentExamLogs => Set<StudentExamLogs>();

        // Model building - Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*/ <----- User - Configuration -----> /*/
            modelBuilder.Entity<User>(builder =>
            {
                // Profile Picture
                builder.Property(u => u.ProfilePic)
                       .HasColumnName("ProfilePicture");

                // Username
                builder.Property(u => u.Username)
                       .IsRequired()
                       .HasColumnName("Username");

                // Email
                builder.Property(u => u.Email)
                       .IsRequired()
                       .HasColumnName("Email");

                builder.HasIndex(u => u.Email)
                       .IsUnique();

                // Password
                builder.Property(u => u.PasswordHash)
                       .IsRequired()
                       .HasColumnName("Password");

                /* ----- Relations ----- */

                // User <-> Students
                builder.HasMany(u => u.Students)
                       .WithOne(s => s.CreatorUser)
                       .OnDelete(DeleteBehavior.Cascade);

                // User <-> Departments
                builder.HasMany(u => u.Departments)
                       .WithOne(d => d.CreatorUser)
                       .OnDelete(DeleteBehavior.Cascade);

                // User <-> Exams
                builder.HasMany(u => u.Exams)
                       .WithOne(e => e.CreatorUser)
                       .OnDelete(DeleteBehavior.Cascade);

                // User <-> Student Exam Logs
                builder.HasMany(u => u.StudentExamLogs)
                       .WithOne(l => l.CreatorUser)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            /*/ <----- Student - Configuration -----> /*/
            modelBuilder.Entity<Student>(builder =>
            {
                // Student Name
                builder.Property(s => s.StudentName)
                       .IsRequired()
                       .HasColumnName("Name");

                // Father Name
                builder.Property(s => s.FatherName)
                       .IsRequired()
                       .HasColumnName("FatherName");

                // Roll Number
                builder.Property(s => s.RollNumber)
                       .IsRequired()
                       .HasColumnName("RollNumber");

                // Date of Birth
                builder.Property(s => s.DateOfBirth)
                       .IsRequired()
                       .HasColumnName("DOB");

                /* ----- Relations ----- */

                // Students <-> Users
                builder.HasOne(s => s.CreatorUser)
                       .WithMany(u => u.Students)
                       .HasForeignKey(s => s.CreatorUserId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Students <-> Department
                builder.HasOne(s => s.Department)
                       .WithMany(d => d.Students)
                       .HasForeignKey(s => s.DepartmentId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Students <-> Student Exams Logs
                builder.HasMany(s => s.StudentExamLogs)
                       .WithOne(l => l.Student)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            /*/ <----- Department - Configuration -----> /*/
            modelBuilder.Entity<Department>(builder =>
            {
                // Name
                builder.Property(d => d.Name)
                       .IsRequired()
                       .HasColumnName("Name");

                builder.HasIndex(d => d.Name)
                       .IsUnique();

                /* ----- Relations ----- */

                // Departments <-> User
                builder.HasOne(d => d.CreatorUser)
                       .WithMany(u => u.Departments)
                       .HasForeignKey(d => d.CreatorUserId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Department <-> Students
                builder.HasMany(d => d.Students)
                       .WithOne(s => s.Department)
                       .OnDelete(DeleteBehavior.Cascade);

                // Department <-> Exams
                builder.HasMany(d => d.Exams)
                       .WithOne(e => e.Department)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            /*/ <----- Exam - Configuration -----> /*/
            modelBuilder.Entity<Exam>(builder =>
            {
                // Type
                builder.Property(e => e.Type)
                       .IsRequired()
                       .HasColumnName("Type");

                // Total Marks
                builder.Property(e => e.TotalMarks)
                       .IsRequired()
                       .HasColumnName("TotalMarks");

                // Conducted Date
                builder.Property(e => e.ConductedDate)
                       .IsRequired()
                       .HasColumnName("ConductedDate");

                /* ----- Relations ----- */

                // Exams <-> User
                builder.HasOne(e => e.CreatorUser)
                       .WithMany(u => u.Exams)
                       .HasForeignKey(e => e.CreatorUserId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Exams <-> Department
                builder.HasOne(e => e.Department)
                       .WithMany(d => d.Exams)
                       .HasForeignKey(e => e.DepartmentId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Exam <-> Student Exams Logs
                builder.HasMany(e => e.StudentExamLogs)
                       .WithOne(l => l.Exam)
                       .OnDelete(DeleteBehavior.Cascade);
            });

            /*/ <----- Student Exam Logs - Configuration -----> /*/
            modelBuilder.Entity<StudentExamLogs>(builder =>
            {
                // Obtained Marks
                builder.Property(l => l.ObtainedMarks)
                       .IsRequired()
                       .HasColumnName("Obtained Marks");

                // Status
                builder.Property(l => l.Status)
                       .IsRequired()
                       .HasColumnName("Status");

                // Note
                builder.Property(l => l.Note)
                       .HasColumnName("Note");

                /* ----- Relations ----- */

                // SELs <-> User
                builder.HasOne(l => l.CreatorUser)
                       .WithMany(u => u.StudentExamLogs)
                       .HasForeignKey(l => l.CreatorUserId)
                       .OnDelete(DeleteBehavior.Restrict);

                // SELs <-> Student
                builder.HasOne(l => l.Student)
                       .WithMany(s => s.StudentExamLogs)
                       .HasForeignKey(l => l.StudentId)
                       .OnDelete(DeleteBehavior.Restrict);

                // SELs <-> Exam
                builder.HasOne(l => l.Exam)
                       .WithMany(e => e.StudentExamLogs)
                       .HasForeignKey(l => l.ExamId)
                       .OnDelete(DeleteBehavior.Restrict);
            });

            // Base configuration
            base.OnModelCreating(modelBuilder);
        }
    }
}
