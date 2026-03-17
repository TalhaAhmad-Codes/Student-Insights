using FluentValidation;
using FluentValidation.AspNetCore;
using StudentInsight.Services.Implementation;
using StudentInsight.Services.Interfaces;

namespace StudentInsight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // AutoMapper Registeration
            builder.Services.AddAutoMapper(typeof(Program));

            // Fluent Validation - Configurations
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            // Services - Configs
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IExamService, ExamService>();
            builder.Services.AddScoped<IStudentExamLogsService, StudentExamLogsService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
