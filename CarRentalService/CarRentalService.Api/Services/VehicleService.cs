using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;
namespace CarRentalService.Api.Services;

public class VehicleService() : IEntityService<VehicleCreateDto, Vehicle>
{
    private readonly List<Vehicle> _vehicles = [];
    private int _vehicleId = 1;

    public List<Vehicle> GetAll() => _vehicles;

    public Vehicle? GetById(int id) => _vehicles.FirstOrDefault(c => c.Id == id);

    public Vehicle Create(VehicleCreateDto dto)
    {
        var newVehicle = new Vehicle
        {
            Id = _vehicleId++,
            Model = dto.Model,
            Color = dto.Color,
        };
        _vehicles.Add(newVehicle);
        return newVehicle;
    }

    public bool Delete(int id)
    {
        var vehicle = GetById(id);
        if (vehicle == null)
        {
            return false;
        }
        return _vehicles.Remove(vehicle);
    }

    public bool Update(int id, VehicleCreateDto updateVehicle)
    {
        var vehicle = GetById(id);
        if (vehicle == null)
        {
            return false;
        }
        vehicle.Model = updateVehicle.Model;
        vehicle.Color = updateVehicle.Color;
        return true;
    }
}
