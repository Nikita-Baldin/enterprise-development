namespace CarRentalService.Api.Dto;
/// <summary>
/// DTO для информации о записях аренд
/// </summary>
public class RecordsInfoDto
{
    /// <summary>
    /// Название модели
    /// </summary>
    public required string VehicleModel { get; set; }
    /// <summary>
    /// Количество аренд
    /// </summary>
    public required int RentalCount { get; set; }
}
