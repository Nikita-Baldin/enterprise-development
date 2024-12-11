using CarRentalService.Api.Dto;
using CarRentalService.Domain.Context;
using CarRentalService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace CarRentalService.Api.Services;

public class RentalPointService(CarRentalServiceDbContext context) : IEntityService<RentalPointCreateDto, RentalPoint>
{
    public async Task<IEnumerable<RentalPoint>> GetAll() => await context.RentalPoints.ToListAsync();

    public async Task<RentalPoint?> GetById(int id) => await context.RentalPoints.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<RentalPoint?> Create(RentalPointCreateDto dto)
    {
        var newRentalPoint = new RentalPoint
        {
            Id = 0,
            Name = dto.Name,
            Address = dto.Address,
        };
        context.RentalPoints.Add(newRentalPoint);
        await context.SaveChangesAsync();
        return newRentalPoint;
    }

    public async Task<bool> Delete(int id)
    {
        var rentalPoint = await GetById(id);
        if (rentalPoint == null)
        {
            return false;
        }
        context.RentalPoints.Remove(rentalPoint);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(int id, RentalPointCreateDto updateRentalPoint)
    {
        var rentalPoint = await GetById(id);
        if (rentalPoint == null)
        {
            return false;
        }
        rentalPoint.Name = updateRentalPoint.Name;
        rentalPoint.Address = updateRentalPoint.Address;
        await context.SaveChangesAsync();
        return true;
    }
}
