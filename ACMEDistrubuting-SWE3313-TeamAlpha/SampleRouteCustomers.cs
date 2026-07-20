namespace ACMEDistrubuting_SWE3313_TeamAlpha;


// hardcoded samples for testing
internal static class SampleRouteCustomers
{
    public static IReadOnlyList<RouteCustomer> Create() =>
    [
        new(
            Guid.Parse("9eaecb02-a082-4f4f-9f95-ae9e1730a101"),
            "Downtown Market",
            "101 Main Street, Atlanta, GA 30303",
            "Tractor trailer dock and forklift available",
            "Monday-Friday, 7:00 AM-2:00 PM"),
        new(
            Guid.Parse("9eaecb02-a082-4f4f-9f95-ae9e1730a102"),
            "Westside Grocery",
            "2250 Westview Drive, Atlanta, GA 30310",
            "Box trucks only; no forklift",
            "Monday-Saturday, 9:00 AM-4:00 PM"),
        new(
            Guid.Parse("9eaecb02-a082-4f4f-9f95-ae9e1730a103"),
            "Peachtree Bottle Shop",
            "810 Peachtree Road, Atlanta, GA 30308",
            "Street unloading; liftgate required",
            "Tuesday-Friday, 10:00 AM-1:00 PM"),
        new(
            Guid.Parse("9eaecb02-a082-4f4f-9f95-ae9e1730a104"),
            "Airport Beverage Center",
            "4000 South Terminal Parkway, Atlanta, GA 30337",
            "Tractor trailer dock; forklift available",
            "Daily, 6:00 AM-11:00 AM"),
        new(
            Guid.Parse("9eaecb02-a082-4f4f-9f95-ae9e1730a105"),
            "North Hills Convenience",
            "75 North Hills Avenue, Atlanta, GA 30305",
            "Box trucks only",
            "Monday-Friday, 8:00 AM-3:00 PM")
    ];
}
