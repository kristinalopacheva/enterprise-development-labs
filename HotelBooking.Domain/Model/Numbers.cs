using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Model;
///<summary>
///Класс Номеров
///</summary>
public class Number
{
    ///<summary>
    ///Индификатор номеров
    ///</summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Тип номера
    ///</summary>
    public string? Type { get; set; }
    ///<summary>
    ///Количество номеров
    ///</summary>
    public int? Quantity { get; set; }
    ///<summary>
    ///Цена номера за ночь
    ///</summary>
    public int? PricePerNight { get; set; }
}

