using CarRentalService.Api.Dto;
using CarRentalService.Api.Services;
using CarRentalService.Domain.Entity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<ClientService>();
builder.Services.AddSingleton<RentalPointService>();
builder.Services.AddSingleton<VehicleService>();
builder.Services.AddSingleton<RentalRecordService>();

builder.Services.AddSingleton<IEntityService<ClientCreateDto, Client>, ClientService>();
builder.Services.AddSingleton<IEntityService<RentalPointCreateDto, RentalPoint>, RentalPointService>();
builder.Services.AddSingleton<IEntityService<RentalRecordCreateDto, RentalRecord>, RentalRecordService>();
builder.Services.AddSingleton<IEntityService<VehicleCreateDto, Vehicle>, VehicleService>();
builder.Services.AddSingleton<RequestService>();


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
