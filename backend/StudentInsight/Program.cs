using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.Repositories.Implementation;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Implementation;
using StudentInsight.Services.Interfaces;
using Supabase;

namespace StudentInsight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Fluent Validation - Configurations
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            // Supabase - Configuration
            //builder.Services.AddScoped<Supabase.Client>(_ =>
            //    new Supabase.Client(
            //        builder.Configuration["SupabaseURL"],
            //        builder.Configuration["SupabaseKey"],
            //        new SupabaseOptions
            //        {
            //            AutoRefreshToken = true,
            //            AutoConnectRealtime = true
            //        }));

            // Database Connection
            //builder.Services.AddDbContext<StudentInsightDbContext>(options =>
            //    options.UseSqlServer(
            //        builder.Configuration.GetConnectionString("DefaultConnection")
            //    ));
            builder.Services.AddDbContext<StudentInsightDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repositories - Configs
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IStudentExamLogsRepository, StudentExamLogsRepository>();

            // Services - Configs
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IExamService, ExamService>();
            builder.Services.AddScoped<IStudentExamLogsService, StudentExamLogsService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Swagger Configs
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<StudentInsightDbContext>();
                db.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
