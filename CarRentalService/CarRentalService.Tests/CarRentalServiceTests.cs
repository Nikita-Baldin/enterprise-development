using CarRentalService.Domain.Entity;

namespace CarRentalService.Tests;

public class CarRentalServiceTests(CarRentalServiceFixture carRentalServiceFixture) : IClassFixture<CarRentalServiceFixture>
{
    private readonly CarRentalServiceFixture _fixture = carRentalServiceFixture;

    [Fact]
    public void GetAllVehiclesShouldReturnAllVehicles()
    {
        var result = _fixture.Vehicles.Count;

        Assert.Equal(5, result);
    }

    [Fact]
    public void GetClientsByVehicleModelReturnsClientsSortedByFullName()
    {
        var targetModel = "Тойота Королла";

        var expectedResult = new List<Client>
        {
            _fixture.Clients[3],
            _fixture.Clients[0],
        };

        var result = _fixture.RentalRecords
            .Where(record => _fixture.Vehicles.Any(vehicle => vehicle.Id == record.VehicleId.Id && vehicle.Model == targetModel))
            .Select(record => _fixture.Clients.First(client => client.Id == record.ClientId.Id))
            .OrderBy(client => client.FullName)
            .Distinct()
            .ToList();

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetVehiclesCurrentlyRentedReturnsActiveRentals()
    {
        var expectedResult = new List<Vehicle>
        {
            _fixture.Vehicles[2],
            _fixture.Vehicles[4]
        };

        var result = _fixture.RentalRecords
            .Where(record => record.RentalEnd == null)
            .Select(record => _fixture.Vehicles.First(vehicle => vehicle.Id == record.VehicleId.Id))
            .Distinct()
            .ToList();

        Assert.Equal(result, expectedResult);
    }

    [Fact]
    public void GetTop5MostRentedVehiclesByModelReturnsCorrectTopModels()
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
              vehicle => vehicle,
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
    public void GetRentalCountForEachVehicleReturnsCorrectRentalCounts()
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
              vehicle => vehicle,
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
    public void GetRentalPointsWithMaxRentalsReturnsCorrectRentalPoints()
    {
        var expectedResult = new[]
        {
            new { _fixture.RentalPoints[1].Name, RentalCount = 2 },
            new { _fixture.RentalPoints[2].Name, RentalCount = 2 }
        };
        var groupedRentals = _fixture.RentalRecords
            .GroupBy(record => record.RentalPointId)
            .Select(group => new
            {
                RentalPointId = group.Key,
                RentalCount = group.Count()
            });
        var maxRentalCount = groupedRentals.Max(rental => rental.RentalCount);
        var result = groupedRentals
            .Where(rental => rental.RentalCount == maxRentalCount)
            .Join(
                _fixture.RentalPoints,
                rental => rental.RentalPointId,
                point => point,
                (rental, point) => new
                {
                    point.Name,
                    rental.RentalCount
                })
            .ToList();
        Assert.Equal(expectedResult, result);
    }
}
