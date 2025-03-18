using HotelBooking.Model;
using HotelBooking.Services;

namespace HotelBooking.Services;

/// <summary>
/// Репозиторий для работы с Клиентами.
/// </summary>
public interface IClientRepository : IRepository<Client, int>
{
    /// <summary>
    /// Получить всех клиентов, совершивших бронирования за указанный период, упорядоченных по ФИО.
    /// </summary>
    /// <param name="startDate">Начальная дата периода.</param>
    /// <param name="endDate">Конечная дата периода.</param>
    /// <returns>Список клиентов.</returns>
    Task<IList<Client>> GetClientsByBookingPeriod(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Получить количество бронирований каждого клиента.
    /// </summary>
    /// <returns>Список клиентов и количества их бронирований.</returns>
    Task<IList<(Client client, int bookingCount)>> GetBookingCountByClient();

    /// <summary>
    /// Получить клиентов, совершивших максимальное количество бронирований за указанный период.
    /// </summary>
    /// <param name="startDate">Начальная дата периода.</param>
    /// <param name="endDate">Конечная дата периода.</param>
    /// <returns>Список клиентов с максимальным числом бронирований.</returns>
    Task<IList<Client>> GetTopClientsByBookingPeriod(DateTime startDate, DateTime endDate);
}