using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Model;
///<summary>
///Класс связывающий отели и номера
///</summary>
public class HotelNubmer
{
    /// <summary>
    /// Идентификатор связи
    /// </summary>
    [Key]
    public required int Id { get; set; }
    /// <summary>
    /// Идентификатор отеля
    /// </summary>
    public required int HotelId { get; set; }
    /// <summary>
    /// Идентификатор номера
    /// </summary>
    public required int NumberId { get; set; }
}

