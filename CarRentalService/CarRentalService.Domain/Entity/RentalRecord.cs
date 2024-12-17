using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalService.Domain.Entity;
/// <summary>
/// класс записи об арендах автомобиля
/// </summary>
[Table("rental_record")]
public class RentalRecord
{
    /// <summary>
    /// идентификатор записи аренды
    /// </summary>
    [Column("id")]
    public required int Id { get; set; }
    /// <summary>
    /// ID автомобиля
    /// </summary>
    [Column("vehicle")]
    [Required]
    public required Vehicle Vehicle { get; set; }
    /// <summary>
    ///  клиент
    /// </summary>
    [Column("client")]
    [Required]
    public required Client Client { get; set; }
    /// <summary>
    /// пункт проката
    /// </summary>
    [Column("rental_point")]
    [Required]
    public required RentalPoint RentalPoint { get; set; }
    /// <summary>
    /// время начала аренды
    /// </summary>
    [Column("rental_start")]
    [Required]
    public required DateTime RentalStart { get; set; }
    /// <summary>
    /// время окончания аренды
    /// </summary>
    [Column("rental_end")]
    public DateTime? RentalEnd { get; set; }
    /// <summary>
    /// ID пункта возврата
    /// </summary>
    [Column("return_point")]
    public RentalPoint? ReturnPoint { get; set; }
    /// <summary>
    /// срок аренды в днях
    /// </summary>
    [Column("rental_duration_days")]
    [Required]
    public required int RentalDurationDays { get; set; } 
}