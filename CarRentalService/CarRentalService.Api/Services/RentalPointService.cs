using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;
namespace CarRentalService.Api.Services;

public class RentalPointService() : IEntityService<RentalPointCreateDto, RentalPoint>
{
    private readonly List<RentalPoint> _rentalPoints = [];
    private int _rentalPointId = 1;

    public List<RentalPoint> GetAll() => _rentalPoints;

    public RentalPoint? GetById(int id) => _rentalPoints.FirstOrDefault(c => c.Id == id);

    public RentalPoint Create(RentalPointCreateDto dto)
    {
        var newRentalPoint = new RentalPoint
        {
            Id = _rentalPointId++,
            Name = dto.Name,
            Address = dto.Address,
        };
        _rentalPoints.Add(newRentalPoint);
        return newRentalPoint;
    }

    public bool Delete(int id)
    {
        var rentalPoint = GetById(id);
        if (rentalPoint == null)
        {
            return false;
        }
        return _rentalPoints.Remove(rentalPoint);
    }

    public bool Update(int id, RentalPointCreateDto updateRentalPoint)
    {
        var rentalPoint = GetById(id);
        if (rentalPoint == null)
        {
            return false;
        }
        rentalPoint.Name = updateRentalPoint.Name;
        rentalPoint.Address = updateRentalPoint.Address;
        return true;
    }
}
