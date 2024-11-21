namespace CarRentalService.Domain.Entity;
/// <summary>
/// класс записи об арендах автомобиля
/// </summary>
public class RentalRecord
{
    /// <summary>
    /// идентификатор записи аренды
    /// </summary>
    public required int Id { get; set; }
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
    /// Время начала аренды
    /// </summary>
    public required DateTime RentalStart { get; set; }
    /// <summary>
    /// Время окончания аренды
    /// </summary>
    public DateTime? RentalEnd { get; set; }
    /// <summary>
    /// ID пункта возврата
    /// </summary>
    public int? ReturnPointId { get; set; }
    /// <summary>
    /// Срок аренды в днях
    /// </summary>
    public required int RentalDurationDays { get; set; } 
}