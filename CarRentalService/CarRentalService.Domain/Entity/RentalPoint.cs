using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalService.Domain.Entity;
/// <summary>
/// класс пункт проката
/// </summary>
[Table("rental_point")]
public class RentalPoint
{
    /// <summary>
    /// уникальный идентификатор пункта проката
    /// </summary>
    [Column("id")]
    public required int Id { get; set; }
    /// <summary>
    /// название пункта проката
    /// </summary>
    [Column("name")]
    [Required]
    public required string Name { get; set; }
    /// <summary>
    /// адрес пункта проката
    /// </summary>
    [Column("address")]
    [Required]
    public required string Address { get; set; } 
}