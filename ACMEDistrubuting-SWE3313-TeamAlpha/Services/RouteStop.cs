using System;

namespace ACMEDistrubuting_SWE3313_TeamAlpha.Models
{
    /// <summary>
    /// Represents one stop on a delivery route.
    /// </summary>
    internal class RouteStop
    {
        public int StopNumber { get; set; }

        public string CustomerId { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string DeliveryWindow { get; set; } = string.Empty;

        public bool HasLoadingDock { get; set; }

        public RouteStop() { }

        public RouteStop(
            int stopNumber,
            string customerId,
            string customerName,
            string address,
            string deliveryWindow,
            bool hasLoadingDock)
        {
            StopNumber = stopNumber;
            CustomerId = customerId;
            CustomerName = customerName;
            Address = address;
            DeliveryWindow = deliveryWindow;
            HasLoadingDock = hasLoadingDock;
        }

        public override string ToString()
        {
            return $"{StopNumber}. {CustomerName}";
        }
    }
}