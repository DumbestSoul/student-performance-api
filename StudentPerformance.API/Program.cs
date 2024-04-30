using Microsoft.EntityFrameworkCore;
using StudentPerformance.Business.Business;
using StudentPerformance.Business.Contract;
using StudentPerformance.Entity.Models;
using StudentPerformance.Repository.Contract;
using StudentPerformance.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


//Dependency Injection
builder.Services.AddScoped<DbContext, SchoolContext>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<ISchoolBusiness, SchoolBusiness>();

//Adding AutoMapper

//DbContext
builder.Services.AddDbContext<SchoolContext>(options => 
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection")
	)
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
