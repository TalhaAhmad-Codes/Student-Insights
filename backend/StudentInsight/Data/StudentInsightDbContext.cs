using Microsoft.EntityFrameworkCore;
using StudentInsight.Entities;
using StudentInsight.Validators.Length;

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
                       .HasMaxLength(MaxLength.Username)
                       .HasColumnName("Username");

                // Email
                builder.Property(u => u.Email)
                       .IsRequired()
                       .HasMaxLength(MaxLength.Email)
                       .HasColumnName("Email");

                builder.HasIndex(u => u.Email)
                       .IsUnique();

                // Password
                builder.Property(u => u.PasswordHash)
                       .IsRequired()
                       .HasColumnName("PasswordHash");
            });

            /*/ <----- Student - Configuration -----> /*/
            modelBuilder.Entity<Student>(builder =>
            {
                // Student Name
                builder.Property(s => s.StudentName)
                       .IsRequired()
                       .HasMaxLength(MaxLength.PersonName)
                       .HasColumnName("Name");

                // Father Name
                builder.Property(s => s.FatherName)
                       .IsRequired()
                       .HasMaxLength(MaxLength.PersonName)
                       .HasColumnName("FatherName");

                // Roll Number
                builder.Property(s => s.RollNumber)
                       .IsRequired()
                       .HasColumnName("RollNumber");

                builder.HasIndex(s => new { s.RollNumber, s.DepartmentId })
                       .IsUnique();

                // Date of Birth
                builder.Property(s => s.DateOfBirth)
                       .IsRequired()
                       .HasColumnName("DOB");

                // Department
                builder.HasIndex(s => s.DepartmentId);

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
            });

            /*/ <----- Department - Configuration -----> /*/
            modelBuilder.Entity<Department>(builder =>
            {
                // Name
                builder.Property(d => d.Name)
                       .IsRequired()
                       .HasMaxLength(MaxLength.DepartmentName)
                       .HasColumnName("Name");

                builder.HasIndex(d => new { d.Name, d.CreatorUserId })
                       .IsUnique();

                // Total Students
                builder.Property(d => d.TotalStudents)
                       .IsRequired()
                       .HasColumnName("TotalStudents");

                /* ----- Relations ----- */

                // Departments <-> User
                builder.HasOne(d => d.CreatorUser)
                       .WithMany(u => u.Departments)
                       .HasForeignKey(d => d.CreatorUserId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Department <-> Students
                builder.HasMany(d => d.Students)
                       .WithOne(s => s.Department)
                       .OnDelete(DeleteBehavior.Restrict);
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
                       .HasColumnName("Marks");

                // Total Students Enrolled
                builder.Property(e => e.TotalStudentsEnrolled)
                       .IsRequired()
                       .HasColumnName("StudentsEnrolled");

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
            });

            /*/ <----- Student Exam Logs - Configuration -----> /*/
            modelBuilder.Entity<StudentExamLogs>(builder =>
            {
                // Obtained Marks
                builder.Property(l => l.ObtainedMarks)
                       .IsRequired()
                       .HasColumnName("ObtainedMarks");

                // Status
                builder.Property(l => l.Status)
                       .IsRequired()
                       .HasColumnName("Status");

                // Note
                builder.Property(l => l.Note)
                       .HasMaxLength(MaxLength.SELNote)
                       .HasColumnName("Note");

                // Prevent duplicate logs
                builder.HasIndex(l => new { l.StudentId, l.ExamId })
                       .IsUnique();

                // Exam
                builder.HasIndex(l => l.ExamId);

                // Student
                builder.HasIndex(l => l.StudentId);

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
