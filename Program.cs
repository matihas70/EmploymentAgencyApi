using EmploymentAgencyApi.DataBase;
using EmploymentAgencyApi.Converters;
using EmploymentAgencyApi.Services;
using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AgencyDbContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IEmployerService, EmployerService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IContractService, ContractService>();


var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();


app.MapControllers();

app.Run();
