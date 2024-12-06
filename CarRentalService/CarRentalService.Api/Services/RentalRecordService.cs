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

        if (client == null || vehicle == null || rentalPoint == null )
        {
            return null;
        }
        var newRentalRecord = new RentalRecord
        {
            Id = _rentalRecordId++,
            VehicleId = vehicle,
            ClientId = client,
            RentalPointId = rentalPoint,
            RentalStart = dto.RentalStart,
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
        var vehicleId = GetById(updateRentalRecord.VehicleId);
        var clientId = GetById(updateRentalRecord.ClientId);
        var rentalPointId = GetById(updateRentalRecord.RentalPointId);
        if (rentalRecord == null || vehicleId == null || clientId == null || rentalPointId == null)
        {
            return false;
        }
        rentalRecord.RentalStart = updateRentalRecord.RentalStart;
        rentalRecord.RentalDurationDays = updateRentalRecord.RentalDurationDays;
        return true;
    }
}

