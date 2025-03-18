using HotelBooking.Services.InMemory;
using HotelBooking.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HotelBooking.Tests;

/// <summary>
/// Класс с юнит-тестами репозитория с бронированиями
/// </summary>
public class BookedRepositoryTests
{
    /// <summary>
    /// Тест проверяет успешное получение статистики по бронированиям номеров.
    /// </summary>
    [Fact]
    public async Task GetNumberBookingStatistics_Success()
    {
        var repo = new BookedInMemoryRepository();
        var statistics = await repo.GetNumberBookingStatistics();

        Assert.NotNull(statistics);
    }
}