namespace CarRentalService.Api.Dto;
/// <summary>
/// DTO для информации о пунктах проката
/// </summary>
public class PointsInfoDto
{
    /// <summary>
    /// Название пункта проката
    /// </summary>
    public required string PointName { get; set; }
    /// <summary>
    /// Количество аренд
    /// </summary>
    public required int RentalCount { get; set; }
}
