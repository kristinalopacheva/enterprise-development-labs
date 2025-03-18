using HotelBooking.Model;
using HotelBooking.Services;
using HotelBooking.Data;

namespace HotelBooking.Services.InMemory;

/// <summary>
/// Реализация репозитория для работы с номерами в памяти.
/// </summary>
public class NumberInMemoryRepository : INumberRepository
{
    private readonly List<Number> _numbers;
    private readonly List<Hotel> _hotels;
    private readonly List<HotelNumber> _hotelNumbers;
    private readonly List<Booked> _bookeds;

    /// <inheritdoc/>
    public NumberInMemoryRepository()
    {
        _numbers = DataSeeder.Numbers;
        _hotels = DataSeeder.Hotels;
        _hotelNumbers = DataSeeder.HotelNumbers;
        _bookeds = DataSeeder.Bookeds;
    }

    /// <inheritdoc/>
    public Task<IList<Number>> GetAll()
    {
        return Task.FromResult<IList<Number>>(_numbers);
    }

    /// <inheritdoc/>
    public Task<Number?> Get(int key)
    {
        var number = _numbers.FirstOrDefault(n => n.Id == key);
        return Task.FromResult(number);
    }

    /// <inheritdoc/>
    public Task<Number> Add(Number entity)
    {
        if (!_numbers.Any(n => n.Id == entity.Id))
        {
            _numbers.Add(entity);
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<Number> Update(Number entity)
    {
        var existingNumber = _numbers.FirstOrDefault(n => n.Id == entity.Id);
        if (existingNumber != null)
        {
            existingNumber.Type = entity.Type;
            existingNumber.Quantity = entity.Quantity;
            existingNumber.PricePerNight = entity.PricePerNight;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<bool> Delete(int key)
    {
        var number = _numbers.FirstOrDefault(n => n.Id == key);
        if (number != null)
        {
            _numbers.Remove(number);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <inheritdoc/>
    public Task<(Number number, Hotel hotel)?> GetNumberWithHotel(int Id)
    {
        var hotelNumber = _hotelNumbers.FirstOrDefault(hn => hn.NumberId == Id);
        if (hotelNumber != null)
        {
            var number = _numbers.FirstOrDefault(n => n.Id == hotelNumber.NumberId);
            var hotel = _hotels.FirstOrDefault(h => h.Id == hotelNumber.HotelId);
            if (number != null && hotel != null)
            {
                return Task.FromResult<(Number, Hotel)?>((number, hotel));
            }
        }
        return Task.FromResult<(Number, Hotel)?>(null);
    }

    /// <inheritdoc/>
    public Task<IList<(Number number, int bookedCount)>> GetTop5NumbersByBookedCount()
    {
        var topNumbers = _bookeds
            .GroupBy(b => b.HotelId)
            .Select(g => new
            {
                Number = _numbers.FirstOrDefault(n => _hotelNumbers.Any(hn => hn.NumberId == n.Id && hn.HotelId == g.Key)),
                BookedCount = g.Count()
            })
            .Where(x => x.Number != null)
            .OrderByDescending(x => x.BookedCount)
            .Take(5)
            .Select(x => (x.Number!, x.BookedCount))
            .ToList();

        return Task.FromResult<IList<(Number, int)>>(topNumbers);
    }

    /// <inheritdoc/>
    public Task<IList<(Number number, int bookedCount, double avgDuration, int maxDuration)>> GetNumberBookedStatistics()
    {
        var numberStats = _bookeds
            .GroupBy(b => b.HotelId)
            .Select(g => new
            {
                Number = _numbers.FirstOrDefault(n => _hotelNumbers.Any(hn => hn.NumberId == n.Id && hn.HotelId == g.Key)),
                BookedCount = g.Count(),
                AvgDuration = g.Average(b => b.Duration ?? 0),
                MaxDuration = g.Max(b => b.Duration ?? 0)
            })
            .Where(x => x.Number != null)
            .Select(x => (x.Number!, x.BookedCount, x.AvgDuration, x.MaxDuration))
            .ToList();

        return Task.FromResult<IList<(Number, int, double, int)>>(numberStats);
    }
}