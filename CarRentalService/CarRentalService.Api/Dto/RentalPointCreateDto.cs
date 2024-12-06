namespace CarRentalService.Api.Dto;

/// <summary>
///  DTO для создания пункта проката
/// </summary>
public class RentalPointCreateDto
{
    /// <summary>
    /// название пункта проката
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// адрес пункта проката
    /// </summary>
    public required string Address { get; set; }
}
