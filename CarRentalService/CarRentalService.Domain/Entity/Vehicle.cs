using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalService.Domain.Entity;

/// <summary>
/// класс транспортное средство
/// </summary>
public class Vehicle
{
    /// <summary>
    /// уникальный номер автомобиля
    /// </summary>
    [Column("id")]
    public required int Id { get; set; }
    /// <summary>
    /// модель автомобиля
    /// </summary>
    [Column("model")]
    [Required]
    public required string Model { get; set; }
    /// <summary>
    /// цвет автомобиля
    /// </summary>
    [Column("color")]
    [Required]
    public required string Color { get; set; }     
}
