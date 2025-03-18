using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Model;
using HotelBooking.Services.InMemory;
using Xunit;

namespace HotelBooking.Tests;

/// <summary>
/// Класс с юнит-тестами репозитория с клиентами
/// </summary>
public class ClientRepositoryTests
{
    /// <summary>
    /// Тест проверяет успешное получение клиентов за указанный период бронирований.
    /// </summary>
    [Fact]
    public async Task GetClientsByBookingPeriod_Success()
    {
        var repo = new ClientInMemoryRepository();
        var clients = await repo.GetClientsByBookingPeriod(new DateTime(2023, 1, 1), new DateTime(2023, 12, 31));

        Assert.NotNull(clients);
    }

    /// <summary>
    /// Тест проверяет успешное получение количества бронирований для каждого клиента.
    /// </summary>
    [Fact]
    public async Task GetBookingCountByClient_Success()
    {
        var repo = new ClientInMemoryRepository();
        var bookingCounts = await repo.GetBookingCountByClient();

        Assert.NotNull(bookingCounts);
    }

    /// <summary>
    /// Тест проверяет успешное получение топ-клиентов по количеству бронирований за указанный период.
    /// </summary>
    [Fact]
    public async Task GetTopClientsByBookingPeriod_Success()
    {
        var repo = new ClientInMemoryRepository();
        var topClients = await repo.GetTopClientsByBookingPeriod(new DateTime(2023, 1, 1), new DateTime(2023, 12, 31));

        Assert.NotNull(topClients);
    }
}