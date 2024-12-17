using CarRentalService.Api.Dto;
using CarRentalService.Domain.Context;
using CarRentalService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace CarRentalService.Api.Services;

public class RentalRecordService(
   IEntityService<ClientCreateDto, Client> clientService,
   IEntityService<RentalPointCreateDto, RentalPoint> rentalPointService,
   IEntityService<VehicleCreateDto, Vehicle> vehicleService,
   CarRentalServiceDbContext context) : IEntityService<RentalRecordCreateDto, RentalRecord>
{
    public async Task<IEnumerable<RentalRecord>> GetAll() => await context.RentalRecords.Include(r => r.Client).Include(r => r.Vehicle).Include(r => r.RentalPoint).ToListAsync();

    public async Task<RentalRecord?> GetById(int id) => await context.RentalRecords.Include(r => r.Client).Include(r => r.Vehicle).Include(r => r.RentalPoint).FirstOrDefaultAsync(c => c.Id == id);

    public async Task<RentalRecord?> Create(RentalRecordCreateDto dto)
    {

        var client = await clientService.GetById(dto.ClientId);
        var rentalPoint = await rentalPointService.GetById(dto.RentalPointId);
        var vehicle = await vehicleService.GetById(dto.VehicleId);
        var returnPoint = await rentalPointService.GetById(dto.ReturnPointId ?? 0);

        if (client == null || vehicle == null || rentalPoint == null || returnPoint == null)
        {
            return null;
        }
        var newRentalRecord = new RentalRecord
        {
            Id = 0,
            Vehicle = vehicle,
            Client = client,
            RentalPoint = rentalPoint,
            RentalStart = dto.RentalStart,
            RentalEnd = dto.RentalEnd,
            ReturnPoint = returnPoint,
            RentalDurationDays = dto.RentalDurationDays,
        };
        context.RentalRecords.Add(newRentalRecord);
        await context.SaveChangesAsync();
        return newRentalRecord;
    }

    public async Task<bool> Delete(int id)
    {
        var rentalRecord = await GetById(id);
        if (rentalRecord == null)
        {
            return false;
        }
        context.RentalRecords.Remove(rentalRecord);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(int id, RentalRecordCreateDto updateRentalRecord)
    {
        var rentalRecord = await GetById(id);
        var vehicleId = await vehicleService.GetById(updateRentalRecord.VehicleId);
        var clientId = await clientService.GetById(updateRentalRecord.ClientId);
        var rentalPointId = await rentalPointService.GetById(updateRentalRecord.RentalPointId);
        var returnPoint = await rentalPointService.GetById(updateRentalRecord.ReturnPointId ?? 0);

        if (rentalRecord == null || vehicleId == null || clientId == null || rentalPointId == null || returnPoint == null)
        {
            return false;
        }
        rentalRecord.Vehicle = vehicleId;
        rentalRecord.Client = clientId;
        rentalRecord.RentalPoint = rentalPointId;
        rentalRecord.RentalStart = updateRentalRecord.RentalStart;
        rentalRecord.RentalEnd = updateRentalRecord.RentalEnd;
        rentalRecord.ReturnPoint = returnPoint;
        rentalRecord.RentalDurationDays = updateRentalRecord.RentalDurationDays;
        await context.SaveChangesAsync();
        return true;
    }
}

