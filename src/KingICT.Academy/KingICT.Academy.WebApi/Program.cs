using KingICT.Academy.Configuration;
using KingICT.Academy.Contract.Academy;
using KingICT.Academy.Contract.Project;
using KingICT.Academy.Contract.Student;
using KingICT.Academy.Model.Academy;
using KingICT.Academy.Model.Project;
using KingICT.Academy.Model.Student;
using KingICT.Academy.Repository.Academy;
using KingICT.Academy.Repository.Common;
using KingICT.Academy.Repository.Project;
using KingICT.Academy.Repository.Student;
using KingICT.Academy.Service.Academy;
using KingICT.Academy.Service.Project;
using KingICT.Academy.Service.Student;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc(options =>
{
	options.EnableEndpointRouting = false;
});

builder.Services.AddApiVersioning(options =>
{
	options.ReportApiVersions = true;
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
});

builder.Services.AddControllers();

builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IAcademyService, AcademyService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IAcademyRepository, AcademyRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

var dbConfig = builder.Configuration.GetSection(nameof(DatabaseConfiguration)).Get<DatabaseConfiguration>();

builder.Services.AddDbContext<AcademyDbContext>(options =>
{
	options.UseSqlServer(dbConfig.ConnectionString);
});

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseMvc();

app.Run();
