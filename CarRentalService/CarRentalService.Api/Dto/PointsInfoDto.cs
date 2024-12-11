using CarRentalService.Domain.Entity;

namespace CarRentalService.Api.Dto;
/// <summary>
/// DTO для информации о пунктах проката
/// </summary>
public class PointsInfoDto
{
    /// <summary>
    /// Название пункта проката
    /// </summary>
    public required RentalPoint Point { get; set; }
    /// <summary>
    /// Количество аренд
    /// </summary>
    public required int RentalCount { get; set; }
}
