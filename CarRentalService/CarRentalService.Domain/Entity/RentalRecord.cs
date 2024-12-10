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
    public required Vehicle Vehicle { get; set; }
    /// <summary>
    ///  клиент
    /// </summary>
    public required Client Client { get; set; }
    /// <summary>
    /// пункт проката
    /// </summary>
    public required RentalPoint RentalPoint { get; set; }
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
    public RentalPoint? ReturnPoint { get; set; }
    /// <summary>
    /// срок аренды в днях
    /// </summary>
    public required int RentalDurationDays { get; set; } 
}