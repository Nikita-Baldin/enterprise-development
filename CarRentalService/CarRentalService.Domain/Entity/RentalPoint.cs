namespace CarRentalService.Domain.Entity;
/// <summary>
/// класс пункт проката
/// </summary>
public class RentalPoint
{
    /// <summary>
    /// уникальный идентификатор пункта проката
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// название пункта проката
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// адрес пункта проката
    /// </summary>
    public required string Address { get; set; } 
}