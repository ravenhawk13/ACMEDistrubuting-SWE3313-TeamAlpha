using System;
using System.Collections.Generic;

namespace ACMEDistrubuting_SWE3313_TeamAlpha.Models
{
    /// <summary>
    /// Represents one manually-created delivery route.
    /// </summary>
    internal class Route
    {
        public string RouteId { get; set; } = Guid.NewGuid().ToString();

        public string SalesRepId { get; set; } = string.Empty;

        public DateTime RouteDate { get; set; }

        public List<RouteStop> Stops { get; set; } = new();

        public List<string> Validate()
        {
            List<string> errors = new();

            if (string.IsNullOrWhiteSpace(SalesRepId))
                errors.Add("Sales Representative ID is required.");

            if (RouteDate == default)
                errors.Add("Route Date is required.");

            if (Stops.Count == 0)
                errors.Add("A route must contain at least one stop.");

            int expectedStop = 1;

            foreach (RouteStop stop in Stops)
            {
                if (stop.StopNumber != expectedStop)
                    errors.Add("Route stop numbers must be sequential.");

                if (string.IsNullOrWhiteSpace(stop.CustomerId))
                    errors.Add($"Stop {expectedStop}: Customer ID required.");

                if (string.IsNullOrWhiteSpace(stop.CustomerName))
                    errors.Add($"Stop {expectedStop}: Customer Name required.");

                expectedStop++;
            }

            return errors;
        }
    }
}