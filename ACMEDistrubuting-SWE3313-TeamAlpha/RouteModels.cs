namespace ACMEDistrubuting_SWE3313_TeamAlpha;

public sealed record RouteCustomer(
    Guid Id,
    string Name,
    string Address,
    string LoadingDockCapabilities,
    string DeliveryHours);

public sealed class DeliveryRoute
{
    private readonly List<RouteCustomer> _stops;

    public DeliveryRoute(
        Guid id,
        string name,
        DateTime routeDate,
        IEnumerable<RouteCustomer>? stops = null)
    {
        Id = id;
        Name = name;
        RouteDate = routeDate.Date;
        _stops = stops?.ToList() ?? [];
    }

    public Guid Id { get; }

    public string Name { get; set; }

    public DateTime RouteDate { get; set; }

    public IReadOnlyList<RouteCustomer> Stops => _stops;

    public bool AddStop(RouteCustomer customer)
    {
        ArgumentNullException.ThrowIfNull(customer);

        if (_stops.Any(stop => stop.Id == customer.Id))
        {
            return false;
        }

        _stops.Add(customer);
        return true;
    }

    public void RemoveStopAt(int index)
    {
        ValidateStopIndex(index);
        _stops.RemoveAt(index);
    }

    public bool MoveStop(int index, int offset)
    {
        ValidateStopIndex(index);

        int destination = index + offset;
        if (destination < 0 || destination >= _stops.Count)
        {
            return false;
        }

        (_stops[index], _stops[destination]) = (_stops[destination], _stops[index]);
        return true;
    }

    public DeliveryRoute Copy() => new(Id, Name, RouteDate, _stops);

    private void ValidateStopIndex(int index)
    {
        if (index < 0 || index >= _stops.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }
}
