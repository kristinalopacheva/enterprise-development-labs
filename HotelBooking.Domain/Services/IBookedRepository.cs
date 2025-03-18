using HotelBooking.Model;
using HotelBooking.Services;

namespace HotelBooking.Services;

/// <summary>
/// Репозиторий для работы с Бронированиями.
/// </summary>
public interface IBookedRepository : IRepository<Booked, int>
{
    /// <summary>
    /// Получить количество бронирований, среднее и максимальное время бронирования для каждого номера.
    /// </summary>
    /// <returns>Список данных о бронированиях номеров.</returns>
    Task<IList<(Number number, int bookingCount, double avgDuration, int maxDuration)>> GetNumberBookingStatistics();
}
