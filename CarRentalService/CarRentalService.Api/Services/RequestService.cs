using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;
namespace CarRentalService.Api.Services;

public class RequestService(VehicleService vehicleService, RentalRecordService recordService, ClientService clientService, RentalPointService pointService)
{
    public IEnumerable<Vehicle> GetAllVehicles()
    {
        return vehicleService.GetAll();
    }
    

    public IEnumerable<Client> GetClientsByVehicleModel (string targetModel)
    {
        var vehicles = vehicleService.GetAll();
        var clients = clientService.GetAll();
        return recordService.GetAll()
            .Where(record => vehicles.Any(vehicle => vehicle.Id == record.VehicleId.Id && vehicle.Model == targetModel))
            .Select(record => clients.First(client => client.Id == record.ClientId.Id))
            .OrderBy(client => client.FullName)
            .Distinct()
            .ToList();
    }

    public IEnumerable<Vehicle> GetVehiclesCurrentlyRented ()
    {
        var records = recordService.GetAll();
        var vehicles = vehicleService.GetAll();
        return records.Where(record => record.RentalEnd == null)
            .Select(record => vehicles.First(vehicle => vehicle.Id == record.VehicleId.Id))
            .Distinct()
            .ToList();
    }

    public IEnumerable<RecordsInfoDto> GetTop5MostRentedVehicles ()
    {
        var records = recordService.GetAll();
        var vehicles = vehicleService.GetAll();
        return records.GroupBy(record => record.VehicleId)
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

    public IEnumerable<RecordsInfoDto> GetRentalCount ()
    {
        var records = recordService.GetAll();
        var vehicles = vehicleService.GetAll();
        return [.. records.GroupBy(record => record.VehicleId)
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

    public IEnumerable<PointsInfoDto> GetRentalPointsWithMaxRentals()
    {
        var records = recordService.GetAll();
        var points = pointService.GetAll();
        var groupedRentals = records
            .GroupBy(record => record.RentalPointId)
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
                    PointName =  point.Name,
                    RentalCount = rental.RentalCount
                })
            .ToList();
    }
}
