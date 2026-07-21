using ACMEDistrubuting_SWE3313_TeamAlpha;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// GENERATED TESTS
namespace ACMEDistrubuting_SWE3313_TeamAlpha.Tests;

[TestClass]
public sealed class RouteStoreTests
{
    private static readonly RouteCustomer CustomerA = new(
        Guid.Parse("fe76a29c-10ed-47c5-a5c0-34d69a1d5a01"),
        "Customer A",
        "1 Main Street",
        "Tractor trailer dock",
        "8:00 AM-2:00 PM");

    private static readonly RouteCustomer CustomerB = new(
        Guid.Parse("fe76a29c-10ed-47c5-a5c0-34d69a1d5a02"),
        "Customer B",
        "2 Main Street",
        "Box trucks only",
        "9:00 AM-3:00 PM");

    [TestMethod]
    public void Save_AddsRouteToSelectedWeek()
    {
        var store = new InMemoryRouteStore();
        DeliveryRoute route = CreateRoute(new DateTime(2026, 7, 20));

        store.Save(route);

        IReadOnlyList<DeliveryRoute> routes =
            store.GetRoutesForWeek(new DateTime(2026, 7, 22));
        Assert.AreEqual(1, routes.Count);
        DeliveryRoute savedRoute = routes[0];
        Assert.AreEqual(route.Id, savedRoute.Id);
        Assert.AreEqual("Monday Route", savedRoute.Name);
    }

    [TestMethod]
    public void Save_UpdatesExistingRoute()
    {
        var store = new InMemoryRouteStore();
        DeliveryRoute route = CreateRoute(new DateTime(2026, 7, 20));
        store.Save(route);

        route.Name = "Updated Route";
        route.AddStop(CustomerB);
        store.Save(route);

        IReadOnlyList<DeliveryRoute> routes =
            store.GetRoutesForWeek(route.RouteDate);
        Assert.AreEqual(1, routes.Count);
        DeliveryRoute savedRoute = routes[0];
        Assert.AreEqual("Updated Route", savedRoute.Name);
        Assert.AreEqual(2, savedRoute.Stops.Count);
    }

    [TestMethod]
    public void Delete_RemovesExistingRoute()
    {
        var store = new InMemoryRouteStore();
        DeliveryRoute route = CreateRoute(new DateTime(2026, 7, 20));
        store.Save(route);

        bool deleted = store.Delete(route.Id);

        Assert.IsTrue(deleted);
        Assert.AreEqual(0, store.GetRoutesForWeek(route.RouteDate).Count);
    }

    [TestMethod]
    public void MoveStop_ChangesManualStopOrder()
    {
        DeliveryRoute route = CreateRoute(new DateTime(2026, 7, 20));
        route.AddStop(CustomerB);

        bool moved = route.MoveStop(1, -1);

        Assert.IsTrue(moved);
        Assert.AreEqual(CustomerB.Id, route.Stops[0].Id);
        Assert.AreEqual(CustomerA.Id, route.Stops[1].Id);
    }

    [TestMethod]
    public void AddStop_RejectsDuplicateCustomer()
    {
        DeliveryRoute route = CreateRoute(new DateTime(2026, 7, 20));

        bool added = route.AddStop(CustomerA);

        Assert.IsFalse(added);
        Assert.AreEqual(1, route.Stops.Count);
    }

    [TestMethod]
    public void Save_RejectsSecondRouteOnSameDate()
    {
        var store = new InMemoryRouteStore();
        DateTime routeDate = new(2026, 7, 20);
        store.Save(CreateRoute(routeDate));
        DeliveryRoute duplicateDateRoute = CreateRoute(routeDate, "Second Route");

        ArgumentException exception = Assert.ThrowsException<ArgumentException>(
            () => store.Save(duplicateDateRoute));

        StringAssert.Contains(exception.Message, "already exists");
    }

    [TestMethod]
    public void GetRoutesForWeek_ExcludesRoutesFromOtherWeeks()
    {
        var store = new InMemoryRouteStore();
        store.Save(CreateRoute(new DateTime(2026, 7, 20)));
        store.Save(CreateRoute(new DateTime(2026, 7, 27), "Next Week"));

        IReadOnlyList<DeliveryRoute> routes =
            store.GetRoutesForWeek(new DateTime(2026, 7, 23));

        Assert.AreEqual(1, routes.Count);
        Assert.AreEqual(new DateTime(2026, 7, 20), routes[0].RouteDate);
    }

    private static DeliveryRoute CreateRoute(
        DateTime routeDate,
        string name = "Monday Route")
    {
        var route = new DeliveryRoute(Guid.NewGuid(), name, routeDate);
        route.AddStop(CustomerA);
        return route;
    }
}
