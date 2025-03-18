using HotelBooking.Model;

namespace HotelBooking.Services;

/// <summary>
/// Репозиторий для работы с номерами.
/// </summary>
public interface INumberRepository : IRepository<Number, int>
{
    /// <summary>
    /// Получить все сведения о конкретном номере и его отеле.
    /// </summary>
    /// <param name="Id">Идентификатор номера.</param>
    /// <returns>Данные о номере и его отеле.</returns>
    Task<(Number number, Hotel hotel)?> GetNumberWithHotel(int Id);

    /// <summary>
    /// Получить топ 5 номеров по количеству бронирований.
    /// </summary>
    /// <returns>Список из 5 номеров и количества их бронирований.</returns>
    Task<IList<(Number number, int bookingCount)>> GetTop5NumbersByBookingCount();

    /// <summary>
    /// Получить информацию о количестве бронирований, среднем и максимальном времени бронирования для каждого номера.
    /// </summary>
    /// <returns>Список номеров с данными по их бронированиям.</returns>
    Task<IList<(Number number, int bookingCount, double avgDuration, int maxDuration)>> GetNumberBookingStatistics();
}