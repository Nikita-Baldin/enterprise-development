using CarRentalService.Api.Dto;
using CarRentalService.Domain.Context;
using CarRentalService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace CarRentalService.Api.Services;

public class VehicleService(CarRentalServiceDbContext context) : IEntityService<VehicleCreateDto, Vehicle>
{
    public async Task<IEnumerable<Vehicle>> GetAll() => await context.Vehicles.ToListAsync();

    public async Task<Vehicle?> GetById(int id) => await context.Vehicles.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Vehicle?> Create(VehicleCreateDto dto)
    {
        var newVehicle = new Vehicle
        {
            Id = 0,
            Model = dto.Model,
            Color = dto.Color,
        };
        context.Vehicles.Add(newVehicle);
        await context.SaveChangesAsync();
        return newVehicle;
    }

    public async Task<bool> Delete(int id)
    {
        var vehicle =await GetById(id);
        if (vehicle == null)
        {
            return false;
        }
        context.Vehicles.Remove(vehicle);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(int id, VehicleCreateDto updateVehicle)
    {
        var vehicle =await GetById(id);
        if (vehicle == null)
        {
            return false;
        }
        vehicle.Model = updateVehicle.Model;
        vehicle.Color = updateVehicle.Color;
        await context.SaveChangesAsync();
        return true;
    }
}
