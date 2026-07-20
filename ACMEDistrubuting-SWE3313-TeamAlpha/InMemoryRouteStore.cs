namespace ACMEDistrubuting_SWE3313_TeamAlpha;

public sealed class InMemoryRouteStore
{
    private readonly List<DeliveryRoute> _routes = [];

    public IReadOnlyList<DeliveryRoute> GetRoutesForWeek(DateTime dateInWeek)
    {
        DateTime weekStart = GetWeekStart(dateInWeek);
        DateTime weekEnd = weekStart.AddDays(7);

        return _routes
            .Where(route => route.RouteDate >= weekStart && route.RouteDate < weekEnd)
            .OrderBy(route => route.RouteDate)
            .ThenBy(route => route.Name)
            .Select(route => route.Copy())
            .ToList();
    }

    public void Save(DeliveryRoute route)
    {
        ArgumentNullException.ThrowIfNull(route);
        Validate(route);

        int existingIndex = _routes.FindIndex(existing => existing.Id == route.Id);
        if (existingIndex >= 0)
        {
            _routes[existingIndex] = route.Copy();
        }
        else
        {
            _routes.Add(route.Copy());
        }
    }

    public bool Delete(Guid routeId)
    {
        int existingIndex = _routes.FindIndex(route => route.Id == routeId);
        if (existingIndex < 0)
        {
            return false;
        }

        _routes.RemoveAt(existingIndex);
        return true;
    }

    public static DateTime GetWeekStart(DateTime date)
    {
        int daysSinceMonday = ((int)date.DayOfWeek + 6) % 7;
        return date.Date.AddDays(-daysSinceMonday);
    }

    private void Validate(DeliveryRoute route)
    {
        if (string.IsNullOrWhiteSpace(route.Name))
        {
            throw new ArgumentException("Enter a route name.", nameof(route));
        }

        if (route.Stops.Count == 0)
        {
            throw new ArgumentException("Add at least one customer stop.", nameof(route));
        }

        if (route.Stops.Select(stop => stop.Id).Distinct().Count() != route.Stops.Count)
        {
            throw new ArgumentException(
                "A customer can appear only once in a route.",
                nameof(route));
        }

        bool dateAlreadyAssigned = _routes.Any(
            existing => existing.Id != route.Id
                && existing.RouteDate.Date == route.RouteDate.Date);

        if (dateAlreadyAssigned)
        {
            throw new ArgumentException(
                "A route already exists for the selected date.",
                nameof(route));
        }
    }
}
