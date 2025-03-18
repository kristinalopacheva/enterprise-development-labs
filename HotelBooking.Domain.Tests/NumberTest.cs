using HotelBooking.Model;
using HotelBooking.Services.InMemory;

namespace HotelBooking.Tests;

/// <summary>
/// Класс юнит-теста репозитория с номерами
/// </summary>
public class NumberRepositoryTests
{
    /// <summary>
    /// Тест проверяет успешное получение номера с его отелем
    /// </summary>
    [Fact]
    public async Task GetNumberWithHotel_Success()
    {
        var repo = new NumberInMemoryRepository();
        var numberHotel = await repo.GetNumberWithHotel(1);

        Assert.NotNull(numberHotel);
        Assert.NotNull(numberHotel?.number);
        Assert.NotNull(numberHotel?.hotel);
    }

    /// <summary>
    /// Тест проверяет успешное получение топ-5 номеров по количеству бронирований
    /// </summary>
    [Fact]
    public async Task GetTop5NumbersByBookingCount_Success()
    {
        var repo = new NumberInMemoryRepository();
        var topNumbers = await repo.GetTop5NumbersByBookingCount();

        Assert.NotNull(topNumbers);
        Assert.True(topNumbers.Count <= 5);
    }

    /// <summary>
    /// Тест проверяет успешное получение статистики по бронированиям номеров
    /// </summary>
    [Fact]
    public async Task GetNumberBookingStatistics_Success()
    {
        var repo = new NumberInMemoryRepository();
        var statistics = await repo.GetNumberBookingStatistics();

        Assert.NotNull(statistics);
    }
}