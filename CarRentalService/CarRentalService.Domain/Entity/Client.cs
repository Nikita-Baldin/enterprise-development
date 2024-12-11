using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalService.Domain.Entity;
/// <summary>
/// класс клиент
/// </summary>
[Table("client")]
public class Client
{
    /// <summary>
    /// идентификатор клиента
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }
    /// <summary>
    /// номер паспорта
    /// </summary>
    [Column("passport_number")]
    [Required]
    public required string PassportNumber { get; set; }
    /// <summary>
    /// ФИО клиента
    /// </summary>
    [Column("full_name")]
    [Required]
    public required string FullName { get; set; }
    /// <summary>
    /// дата рождения клиента
    /// </summary>
    [Column("birth_date")]
    [Required]
    public required DateTime BirthDate { get; set; }
}