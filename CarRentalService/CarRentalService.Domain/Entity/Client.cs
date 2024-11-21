namespace CarRentalService.Domain.Entity;
/// <summary>
/// класс клиент
/// </summary>
public class Client
{
    /// <summary>
    /// идентификатор клиента
    /// </summary>
    public required int Id { get; set; }
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