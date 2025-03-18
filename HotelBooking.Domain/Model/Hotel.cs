using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Model;
///<summary>
///Класс отели
///</summary>
public class Hotel
{
    /// <summary>
    /// Индификатор отеля
    /// </summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Наименование отеля 
    ///</summary>
    public string? Name { get; set; }

    ///<summary>
    ///Расположение отеля,город 
    ///</summary>
    public string? City { get; set; }

    ///<summary>
    ///Адрес отеля 
    ///</summary>
    public string? Address { get; set; }
}

