using Microsoft.EntityFrameworkCore;
using MLT.Rifa2.API;
using MLT.Rifa2.API.Interfaces;
using MLT.Rifa2.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Rifa2DbContext>(options => options.UseSqlServer("name=DefaultConnection"));

builder.Services.AddScoped<IOrganizationTypeService, OrganizationTypeService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IOrganizationFormService, OrganizationFormService>();
builder.Services.AddScoped<IGenericService, GenericService>();
builder.Services.AddScoped<IReferentService, ReferentService>();

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
