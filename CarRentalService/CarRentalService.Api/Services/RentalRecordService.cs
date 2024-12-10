using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;
namespace CarRentalService.Api.Services;

public class RentalRecordService(ClientService clientService, RentalPointService rentalPointService, VehicleService vehicleService) : IEntityService<RentalRecordCreateDto, RentalRecord>
{
    private readonly List<RentalRecord> _rentalRecords = [];
    private int _rentalRecordId = 1;

    public List<RentalRecord> GetAll() => _rentalRecords;

    public RentalRecord? GetById(int id) => _rentalRecords.FirstOrDefault(c => c.Id == id);

    public RentalRecord? Create(RentalRecordCreateDto dto)
    {

        var client = clientService.GetById(dto.ClientId);
        var rentalPoint = rentalPointService.GetById(dto.RentalPointId);
        var vehicle = vehicleService.GetById(dto.VehicleId);
        var returnPoint = rentalPointService.GetById(dto.ReturnPointId ?? 0);

        if (client == null || vehicle == null || rentalPoint == null || returnPoint == null)
        {
            return null;
        }
        var newRentalRecord = new RentalRecord
        {
            Id = _rentalRecordId++,
            Vehicle = vehicle,
            Client = client,
            RentalPoint = rentalPoint,
            RentalStart = dto.RentalStart,
            RentalEnd = dto.RentalEnd,
            ReturnPoint = returnPoint,
            RentalDurationDays = dto.RentalDurationDays,
        };
        _rentalRecords.Add(newRentalRecord);
        return newRentalRecord;
    }

    public bool Delete(int id)
    {
        var rentalRecord = GetById(id);
        if (rentalRecord == null)
        {
            return false;
        }
        return _rentalRecords.Remove(rentalRecord);
    }

    public bool Update(int id, RentalRecordCreateDto updateRentalRecord)
    {
        var rentalRecord = GetById(id);
        var vehicleId = vehicleService.GetById(updateRentalRecord.VehicleId);
        var clientId = clientService.GetById(updateRentalRecord.ClientId);
        var rentalPointId = rentalPointService.GetById(updateRentalRecord.RentalPointId);
        var returnPoint = rentalPointService.GetById(updateRentalRecord.ReturnPointId ?? 0);

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
        return true;
    }
}

