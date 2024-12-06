namespace CarRentalService.Api.Dto;

/// <summary>
/// DTO для создания записей об аренде автомобилей
/// </summary>
public class RentalRecordCreateDto
{
    /// <summary>
    /// ID автомобиля
    /// </summary>
    public required int VehicleId { get; set; }
    /// <summary>
    /// ID клиента
    /// </summary>
    public required int ClientId { get; set; }
    /// <summary>
    /// ID пункта проката
    /// </summary>
    public required int RentalPointId { get; set; }
    /// <summary>
    /// время начала аренды
    /// </summary>
    public required DateTime RentalStart { get; set; }
    /// <summary>
    /// время окончания аренды
    /// </summary>
    public DateTime? RentalEnd { get; set; }
    /// <summary>
    /// ID пункта возврата
    /// </summary>
    public int? ReturnPointId { get; set; }
    /// <summary>
    /// срок аренды в днях
    /// </summary>
    public required int RentalDurationDays { get; set; }
}
