using HotelBooking.Domain.Model;

namespace HotelBooking.Domain.Data;

/// <summary>
/// Коллекция отелей для начального наполнения
/// </summary>
public static readonly List<Hotel> Hotel =
[
        new() { Id = 1, Name = "Camry Hotel", City = "Москва", Address = "ул. Ленина, 1" },
        new() { Id = 2, Name = "Sonata Hotel", City = "Санкт-Петербург", Address = "ул. Пушкина, 2" },
        new() { Id = 3, Name = "Focus Hotel", City = "Екатеринбург", Address = "ул. Гагарина, 3" },
        new() { Id = 4, Name = "Optima Hotel", City = "Новосибирск", Address = "ул. Мира, 4" },
        new() { Id = 5, Name = "Passat Hotel", City = "Казань", Address = "ул. Советская, 5" }
];

/// <summary>
/// Коллекция номеров для начального наполнения
/// </summary>
public static readonly List<Number> Number =
[
        new() { Id = 1, Type = "Стандарт", Quantity = 10, PricePerNight = 3000 },
        new() { Id = 2, Type = "Люкс", Quantity = 5, PricePerNight = 5000 },
        new() { Id = 3, Type = "Эконом", Quantity = 20, PricePerNight = 2000 },
        new() { Id = 4, Type = "Семейный", Quantity = 8, PricePerNight = 4000 },
        new() { Id = 5, Type = "Делюкс", Quantity = 3, PricePerNight = 7000 }
];

/// <summary>
/// Коллекция связей отелей и номеров
/// </summary>
public static readonly List<HotelNumber> HotelNumber =
[
        new() { Id = 1, HotelId = 1, NumberId = 1 },
        new() { Id = 2, HotelId = 2, NumberId = 2 },
        new() { Id = 3, HotelId = 3, NumberId = 3 },
        new() { Id = 4, HotelId = 4, NumberId = 4 },
        new() { Id = 5, HotelId = 5, NumberId = 5 }
];

/// <summary>
/// Коллекция клиентов
/// </summary>
public static readonly List<Client> Client =
[
        new() { Id = 1, FirstName = "Мария", LastName = "Смирнова", Passport = "1234 567890", BirthDate = 19900809 },
        new() { Id = 2, FirstName = "Ольга", LastName = "Козлова", Passport = "2345 678901", BirthDate = 19761009 },
        new() { Id = 3, FirstName = "Павел", LastName = "Морозов", Passport = "3456 789012", BirthDate = 20030106 },
        new() { Id = 4, FirstName = "Анна", LastName = "Васильева", Passport = "4567 890123", BirthDate = 20001010 },
        new() { Id = 5, FirstName = "Роман", LastName = "Зайцев", Passport = "5678 901234", BirthDate = 19871111 }
];

/// <summary>
/// Коллекция бронирований
/// </summary>
public static readonly List<Booked> Booked =
[
        new() { Id = 1, HotelId = 1, CheckInDate = new DateTime(2024, 2, 15), Duration = 3 },
        new() { Id = 2, HotelId = 2, CheckInDate = new DateTime(2024, 2, 16), Duration = 2 },
        new() { Id = 3, HotelId = 3, CheckInDate = new DateTime(2024, 2, 17), Duration = 5 },
        new() { Id = 4, HotelId = 4, CheckInDate = new DateTime(2024, 2, 18), Duration = 4 },
        new() { Id = 5, HotelId = 5, CheckInDate = new DateTime(2024, 2, 19), Duration = 7 }
];

/// <summary>
/// Коллекция связей клиентов и бронирований
/// </summary>
public static readonly List<ClientBooked> ClientBooked =
[
        new() { Id = 1, ClientId = 1, BookedId = 1 },
        new() { Id = 2, ClientId = 2, BookedId = 2 },
        new() { Id = 3, ClientId = 3, BookedId = 3 },
        new() { Id = 4, ClientId = 4, BookedId = 4 },
        new() { Id = 5, ClientId = 5, BookedId = 5 }
