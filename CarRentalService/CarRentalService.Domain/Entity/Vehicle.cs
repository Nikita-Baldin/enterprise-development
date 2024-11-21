namespace CarRentalService.Domain.Entity;

/// <summary>
/// класс транспортное средство
/// </summary>
public class Vehicle
{
    /// <summary>
    /// уникальный номер автомобиля
    /// </summary>
    public required int Id { get; set; }  
    /// <summary>
    /// модель автомобиля
    /// </summary>
    public required string Model { get; set; }   
    /// <summary>
    /// цвет автомобиля
    /// </summary>
    public required string Color { get; set; }     
}
