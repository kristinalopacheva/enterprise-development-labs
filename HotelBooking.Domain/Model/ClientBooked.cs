using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Model;
///<summary>
///Класс связывающий клиента и бронирование
///</summary>
public class ClientBooked
{
    /// <summary>
    /// Идентификатор связи
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public required int ClientId { get; set; }

    /// <summary>
    /// Идентификатор брони
    /// </summary>
    public required int BookedId { get; set; }
}

