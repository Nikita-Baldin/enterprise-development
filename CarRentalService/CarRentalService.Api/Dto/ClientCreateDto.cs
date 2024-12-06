namespace CarRentalService.Api.Dto;

/// <summary>
/// DTO для создания клиента
/// </summary>
public class ClientCreateDto
{
    /// <summary>
    /// номер паспорта
    /// </summary>
    public required string PassportNumber { get; set; }
    /// <summary>
    /// ФИО клиента
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// дата рождения клиента
    /// </summary>
    public required DateTime BirthDate { get; set; }
}
