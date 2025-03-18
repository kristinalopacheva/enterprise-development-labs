using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Model;
///<summary>
///Класс клиент
///</summary>
public class Client
{
    /// <summary>
    /// Индификатор клиента 
    /// </summary>
    [Key]
    public required int Id { get; set; }
    ///<summary>
    ///Фамилия клиента 
    ///</summary>
    public string? FirstName { get; set; }

    ///<summary>
    ///Имя клиента
    ///</summary>
    public string? LastName { get; set; }

    ///<summary>
    ///Паспорт Клиента 
    ///</summary>
    public string? Passport { get; set; }
    ///<summary>
    ///Дата рождения клиента
    ///</summary>
    public int? BirthDate { get; set; }
}

