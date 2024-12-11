using CarRentalService.Api.Dto;
using CarRentalService.Domain.Context;
using CarRentalService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace CarRentalService.Api.Services;

public class RequestService(
    IEntityService<ClientCreateDto, Client> clientService,
    IEntityService<RentalPointCreateDto, RentalPoint> pointService,
    IEntityService<VehicleCreateDto, Vehicle> vehicleService,
    IEntityService<RentalRecordCreateDto, RentalRecord> recordService,
    CarRentalServiceDbContext context)
{
    public async Task<IEnumerable<Vehicle>> GetAllVehicles()
    {
        return await context.Vehicles.ToListAsync();
    }
    

    public async Task<IEnumerable<Client>> GetClientsByVehicleModel (string targetModel)
    {
        var vehicles = await vehicleService.GetAll();
        var clients = await clientService.GetAll();
        var records = await recordService.GetAll();
        return records
            .Where(record => vehicles.Any(vehicle => vehicle.Id == record.Vehicle.Id && vehicle.Model == targetModel))
            .Select(record => clients.First(client => client.Id == record.Client.Id))
            .OrderBy(client => client.FullName)
            .Distinct()
            .ToList();
    }

    public async Task<IEnumerable<Vehicle>> GetVehiclesCurrentlyRented ()
    {
        var records = await recordService.GetAll();
        var vehicles = await vehicleService.GetAll();
        return records
            .Where(record => record.RentalEnd == null)
            .Select(record => vehicles.First(vehicle => vehicle.Id == record.Vehicle.Id))
            .Distinct()
            .ToList();
    }

    public async Task<IEnumerable<RecordsInfoDto>> GetTop5MostRentedVehicles ()
    {
        var records = await recordService.GetAll();
        var vehicles = await vehicleService.GetAll();
        return records.GroupBy(record => record.Vehicle)
              .Join(vehicles,
                  record => record.Key,
                  vehicle => vehicle,
                  (record, vehicle) => new RecordsInfoDto
                  {
                      VehicleModel = vehicle.Model,
                      RentalCount = record.Count()
                  })
              .OrderByDescending(vehicleInfo => vehicleInfo.RentalCount)
              .Take(5)
              .ToList();
    }

    public async Task<IEnumerable<RecordsInfoDto>> GetRentalCount ()
    {
        var records = await recordService.GetAll();
        var vehicles = await vehicleService.GetAll();
        return [.. records.GroupBy(record => record.Vehicle)
              .Join(vehicles,
                  record => record.Key,
                  vehicle => vehicle,
                  (record, vehicle) => new RecordsInfoDto
                  {
                      VehicleModel = vehicle.Model,
                      RentalCount = record.Count()
                  })
              .OrderByDescending(vehicleInfo => vehicleInfo.RentalCount)];
    }

    public async Task<IEnumerable<PointsInfoDto>> GetRentalPointsWithMaxRentals()
    {
        var records = await recordService.GetAll();
        var points = await pointService.GetAll();
        var groupedRentals = records
            .GroupBy(record => record.RentalPoint)
            .Select(group => new
            {
                RentalPointId = group.Key,
                RentalCount = group.Count()
            });
        if (!groupedRentals.Any())
        {
            return [];
        }
        var maxRentalCount = groupedRentals.Max(rental => rental.RentalCount);
        return groupedRentals
            .Where(rental => rental.RentalCount == maxRentalCount)
            .Join(
                points,
                rental => rental.RentalPointId,
                point => point,
                (rental, point) => new PointsInfoDto
                {
                    Point =  point,
                    RentalCount = rental.RentalCount
                })
            .ToList();
    }
}
