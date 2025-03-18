using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Model;
///<summary>
///Класс бронирования
///</summary>
public class Booked
{
    ///<summary>
    ///Индификатор брони
    ///</summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Идентификатор отеля 
    ///</summary>
    public required string? HotelId { get; set; }
    ///<summary>
    ///Дата бронирования
    ///</summary>
    public DateTime? CheckInDate { get; set; }
    ///<summary>
    ///Длительность пребывания
    ///</summary>
    public int? Duration { get; set; }
}

