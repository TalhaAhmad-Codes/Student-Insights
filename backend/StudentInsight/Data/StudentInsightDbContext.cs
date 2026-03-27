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
        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<Subject> Subjects => Set<Subject>();
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

                builder.HasIndex(s => s.RollNumber)
                       .IsUnique();

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
            });

            /*/ <----- Subject - Configuration -----> /*/
            modelBuilder.Entity<Subject>(builder =>
            {
                // Name
                builder.Property(s => s.Name)
                       .IsRequired()
                       .HasMaxLength(MaxLength.SubjectName)
                       .HasColumnName("Name");

                // Unique name per user
                builder.HasIndex(s => new { s.Name, s.CreatorUserId })
                       .IsUnique();

                /* ----- Relations ----- */

                // Subjects <-> User
                builder.HasOne(s => s.CreatorUser)
                       .WithMany(u => u.Subjects)
                       .HasForeignKey(s => s.CreatorUserId)
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
                builder.Property(e => e.DateOfConduct)
                       .IsRequired()
                       .HasColumnName("DateOfConduct");

                /* ----- Relations ----- */

                // Exams <-> User
                builder.HasOne(e => e.CreatorUser)
                       .WithMany(u => u.Exams)
                       .HasForeignKey(e => e.CreatorUserId)
                       .OnDelete(DeleteBehavior.Restrict);

                // Exams <-> Subject
                builder.HasOne(e => e.Subject)
                       .WithMany(d => d.Exams)
                       .HasForeignKey(e => e.SubjectId)
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
