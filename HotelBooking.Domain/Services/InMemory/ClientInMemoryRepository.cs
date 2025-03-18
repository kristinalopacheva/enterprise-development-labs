using HotelBooking.Data;
using HotelBooking.Model;

namespace HotelBooking.Services.InMemory;

/// <summary>
/// Имплементация репозитория для Клиентов, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class ClientInMemoryRepository : IClientRepository
{
    private List<Client> _clients;
    private List<ClientBooking> _clientBookings;
    private List<Booked> _bookeds;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public ClientInMemoryRepository()
    {
        _clients = DataSeeder.Clients;
        _clientBookings = DataSeeder.ClientBookings;
        _bookeds = DataSeeder.Bookeds;
    }

    /// <inheritdoc/>
    public Task<Client> Add(Client entity)
    {
        _clients.Add(entity);
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        var client = await Get(key);
        if (client != null)
        {
            _clients.Remove(client);
            return true;
        }
        return false;
    }

    /// <inheritdoc/>
    public async Task<Client> Update(Client entity)
    {
        try
        {
            await Delete(entity.Id);
            await Add(entity);
        }
        catch
        {
            return null!;
        }
        return entity;
    }

    /// <inheritdoc/>
    public Task<Client?> Get(int key) =>
        Task.FromResult(_clients.FirstOrDefault(c => c.Id == key));

    /// <inheritdoc/>
    public Task<IList<Client>> GetAll() =>
        Task.FromResult((IList<Client>)_clients);

    /// <inheritdoc/>
    public Task<IList<Client>> GetClientsByBookingPeriod(DateTime startDate, DateTime endDate)
    {
        var clients = _clientBookings
            .Where(cb => _bookeds.Any(b => b.Id == cb.BookedId && b.CheckInDate >= startDate && b.CheckInDate <= endDate))
            .Select(cb => _clients.FirstOrDefault(c => c.Id == cb.ClientId))
            .Where(c => c != null)
            .Select(c => c!)
            .OrderBy(c => c.LastName)
            .ToList();

        return Task.FromResult<IList<Client>>(clients);
    }

    /// <inheritdoc/>
    public Task<IList<(Client client, int bookingCount)>> GetBookingCountByClient()
    {
        var bookingCounts = _clientBookings
            .GroupBy(cb => cb.ClientId)
            .Select(g => (client: _clients.FirstOrDefault(c => c.Id == g.Key), bookingCount: g.Count()))
            .Where(x => x.client != null)
            .ToList();

        return Task.FromResult((IList<(Client, int)>)bookingCounts);
    }

    /// <inheritdoc/>
    public Task<IList<Client>> GetTopClientsByBookingPeriod(DateTime startDate, DateTime endDate)
    {
        var topClients = _clientBookings
            .Where(cb => _bookeds.Any(b => b.Id == cb.BookedId && b.CheckInDate >= startDate && b.CheckInDate <= endDate))
            .GroupBy(cb => cb.ClientId)
            .OrderByDescending(g => g.Count())
            .Select(g => _clients.FirstOrDefault(c => c.Id == g.Key))
            .Where(c => c != null)
            .Select(c => c!)
            .ToList();

        return Task.FromResult<IList<Client>>(topClients);
    }
}