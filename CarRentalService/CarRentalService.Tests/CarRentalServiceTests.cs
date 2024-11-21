using CarRentalService.Domain.Entity;

namespace CarRentalService.Tests;

public class CarRentalServiceTests(CarRentalServiceFixture carRentalServiceFixture) : IClassFixture<CarRentalServiceFixture>
{
    private readonly CarRentalServiceFixture _fixture = carRentalServiceFixture;

    [Fact]
    public void GetAllVehicles_ShouldReturnAllVehicles()
    {
        var result = _fixture.Vehicles.Count;

        Assert.Equal(5, result);
    }

    [Fact]
    public void GetClientsByVehicleModel_ReturnsClientsSortedByFullName()
    {
        string targetModel = "Тойота Королла";

        var expectedResult = new List<Client>
        {
            _fixture.Clients[3],
            _fixture.Clients[0],
        };

        var result = _fixture.RentalRecords
            .Where(record => _fixture.Vehicles.Any(vehicle => vehicle.Id == record.VehicleId && vehicle.Model == targetModel))
            .Select(record => _fixture.Clients.First(client => client.Id == record.ClientId))
            .OrderBy(client => client.FullName)
            .Distinct()
            .ToList();

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetVehiclesCurrentlyRented_ReturnsActiveRentals()
    {
        var expectedResult = new List<Vehicle>
        {
            _fixture.Vehicles[2],
            _fixture.Vehicles[4]
        };

        var result = _fixture.RentalRecords
            .Where(record => record.RentalEnd == null)
            .Select(record => _fixture.Vehicles.First(vehicle => vehicle.Id == record.VehicleId))
            .Distinct()
            .ToList();

        Assert.Equal(result, expectedResult);
    }

    [Fact]
    public void GetTop5MostRentedVehiclesByModel_ReturnsCorrectTopModels()
    {
        var expectedResult = new[]
        {
            new { _fixture.Vehicles[0].Model, RentalCount = 1 },
            new { _fixture.Vehicles[1].Model, RentalCount = 1 },
            new { _fixture.Vehicles[2].Model, RentalCount = 1 },
            new { _fixture.Vehicles[3].Model, RentalCount = 1 },
            new { _fixture.Vehicles[4].Model, RentalCount = 1 }
        };

        var result = _fixture.RentalRecords
          .GroupBy(record => record.VehicleId)
          .Join(_fixture.Vehicles,
              record => record.Key,
              vehicle => vehicle.Id,
              (record, vehicle) => new
              {
                  vehicle.Model,
                  RentalCount = record.Count()
              })
          .OrderByDescending(vehicleInfo => vehicleInfo.RentalCount)
          .Take(5)
          .ToList();

        Assert.Equal(expectedResult, result);

    }

    [Fact]
    public void GetRentalCountForEachVehicle_ReturnsCorrectRentalCounts()
    {
        var expectedResult = new[]
        {
            new { _fixture.Vehicles[0].Model, RentalCount = 1 },
            new { _fixture.Vehicles[1].Model, RentalCount = 1 },
            new { _fixture.Vehicles[2].Model, RentalCount = 1 },
            new { _fixture.Vehicles[3].Model, RentalCount = 1 },
            new { _fixture.Vehicles[4].Model, RentalCount = 1 }
        };

        var result = _fixture.RentalRecords
          .GroupBy(record => record.VehicleId) 
          .Join(_fixture.Vehicles, 
              record => record.Key,  
              vehicle => vehicle.Id, 
              (record, vehicle) => new
              {
                  vehicle.Model,  
                  RentalCount = record.Count()  
              })
          .OrderByDescending(vehicleInfo => vehicleInfo.RentalCount)  
          .ToList();

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetRentalPointsWithMaxRentals_ReturnsCorrectRentalPoints()
    {
        var expectedResult = new[]
        {
            new { _fixture.RentalPoints[1].Name, RentalCount = 2 },
            new { _fixture.RentalPoints[2].Name, RentalCount = 2 },
            new { _fixture.RentalPoints[0].Name, RentalCount = 1 }
        };

        var result = _fixture.RentalRecords
         .GroupBy(record => record.RentalPointId)
         .Select(group => new
         {
             RentalPointId = group.Key,  
             RentalCount = group.Count()  
         })
         .OrderByDescending(rentalPoint => rentalPoint.RentalCount)  
         .Join(_fixture.RentalPoints,  
             rental => rental.RentalPointId,  
             point => point.Id,
             (rental, point) => new
             {
                 point.Name,
                 rental.RentalCount
             })
         .ToList();

        Assert.Equal(expectedResult, result);
    }
}
