using CarRentalService.Api.Dto;
using CarRentalService.Api.Services;
using CarRentalService.Domain.Context;
using CarRentalService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<CarRentalServiceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IEntityService<ClientCreateDto, Client>, ClientService>();
builder.Services.AddScoped<IEntityService<RentalPointCreateDto, RentalPoint>, RentalPointService>();
builder.Services.AddScoped<IEntityService<RentalRecordCreateDto, RentalRecord>, RentalRecordService>();
builder.Services.AddScoped<IEntityService<VehicleCreateDto, Vehicle>, VehicleService>();
builder.Services.AddScoped<RequestService>();


builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();
