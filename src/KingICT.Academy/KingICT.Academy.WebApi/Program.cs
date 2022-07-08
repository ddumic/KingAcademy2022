using KingICT.Academy.Configuration;
using KingICT.Academy.Contract.Academy;
using KingICT.Academy.Model.Academy;
using KingICT.Academy.Repository.Academy;
using KingICT.Academy.Repository.Common;
using KingICT.Academy.Service.Academy;
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

builder.Services.AddTransient<IAcademyService, AcademyService>();
builder.Services.AddTransient<IAcademyRepository, AcademyRepository>();

var dbConfig = builder.Configuration.GetSection(nameof(DatabaseConfiguration)).Get<DatabaseConfiguration>();

builder.Services.AddDbContext<AcademyDbContext>(options =>
{
	options.UseSqlServer(dbConfig.ConnectionString);
});

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseMvc();

app.Run();
