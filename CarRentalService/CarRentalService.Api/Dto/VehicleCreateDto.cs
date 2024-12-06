namespace CarRentalService.Api.Dto;

/// <summary>
/// DTO для создания автомобиля
/// </summary>
public class VehicleCreateDto
{
    /// <summary>
    /// модель автомобиля
    /// </summary>
    public required string Model { get; set; }
    /// <summary>
    /// цвет автомобиля
    /// </summary>
    public required string Color { get; set; }
}
