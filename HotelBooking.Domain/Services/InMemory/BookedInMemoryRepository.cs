using HotelBooking.Data;
using HotelBooking.Model;

namespace HotelBooking.Services.InMemory;

/// <summary>
/// Имплементация репозитория для Бронирований, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class BookedInMemoryRepository : IBookedRepository
{
    private readonly List<Booked> _bookeds;
    private readonly List<Number> _numbers;
    private readonly List<HotelNumber> _hotelNumbers;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public BookedInMemoryRepository()
    {
        _bookeds = DataSeeder.Bookeds;
        _numbers = DataSeeder.Numbers;
        _hotelNumbers = DataSeeder.HotelNumbers;
    }

    /// <inheritdoc/>
    public Task<Booked> Add(Booked entity)
    {
        _bookeds.Add(entity);
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        var booked = await Get(key);
        if (booked != null)
        {
            _bookeds.Remove(booked);
            return true;
        }
        return false;
    }

    /// <inheritdoc/>
    public Task<Booked> Update(Booked entity)
    {
        var existingBooked = _bookeds.FirstOrDefault(b => b.Id == entity.Id);
        if (existingBooked != null)
        {
            existingBooked.Id = entity.Id;
            existingBooked.CheckInDate = entity.CheckInDate;
            existingBooked.CheckOutDate = entity.CheckOutDate;
            existingBooked.Duration = entity.Duration;
            existingBooked.Cost = entity.Cost;
            existingBooked.HotelId = entity.HotelId;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<Booked?> Get(int key) =>
        Task.FromResult(_bookeds.FirstOrDefault(b => b.Id == key));

    /// <inheritdoc/>
    public Task<IList<Booked>> GetAll() =>
        Task.FromResult((IList<Booked>)_bookeds);

    /// <inheritdoc/>
    public Task<IList<(Number number, int bookedCount, double avgDuration, int maxDuration)>> GetNumberBookedStatistics()
    {
        var statistics = _bookeds
            .GroupBy(b => b.HotelId)
            .Select(g =>
            {
                var hotelNumber = _hotelNumbers.FirstOrDefault(hn => hn.HotelId == g.Key);
                var number = hotelNumber != null ? _numbers.FirstOrDefault(n => n.Id == hotelNumber.NumberId) : null;
                return number != null
                    ? (number, g.Count(), g.Average(b => b.Duration ?? 0), g.Max(b => b.Duration ?? 0))
                    : default;
            })
            .Where(stat => stat.number != null)
            .ToList();

        return Task.FromResult((IList<(Number, int, double, int)>)statistics);
    }
}