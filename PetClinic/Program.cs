using Microsoft.EntityFrameworkCore;
using PetClinic.Mapper;
using PetClinic.Model.Repository;
using PetClinic.Model.Repository.Implementation;
using PetClinic.Model.Repository.Interfaces;
using PetClinic.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//AutoMappers
builder.Services.AddAutoMapper(typeof(ClientAutoMapperProfile));

//Validators
builder.Services.AddScoped<ClientValidator>();

//Entity Framework
builder.Services.AddDbContext<PetClinicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"))
);
builder.Services.AddScoped<IPetClinicRepository, PetClinicRepository>();

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

public partial class Program { }
