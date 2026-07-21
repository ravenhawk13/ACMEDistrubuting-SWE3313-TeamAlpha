using System;
using System.Collections.Generic;
using System.Text;

namespace ACMEDistrubuting_SWE3313_TeamAlpha.Models
{
    /// <summary>
    /// Represents a completed customer order, matching the fields on Acme's paper order
    /// form: Account ID, Delivery Date, Sales Rep ID, Delivery Rep ID, and the ordered
    /// line items.
    /// </summary>
    internal class Order
    {
        /// <summary>The customer/account this order is being placed for.</summary>
        public string AccountId { get; set; } = string.Empty;

        /// <summary>The date the order is scheduled to be delivered.</summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>ID of the sales representative who took the order (captured at login).</summary>
        public string SalesRepId { get; set; } = string.Empty;

        /// <summary>ID of the representative who will deliver the order.</summary>
        public string DeliveryRepId { get; set; } = string.Empty;

        /// <summary>The line items on this order.</summary>
        public List<OrderItem> Items { get; set; } = new();

        /// <summary>
        /// Checks the order against the required fields on the sample order form.
        /// </summary>
        /// <returns>A list of human-readable problems; an empty list means the order is valid.</returns>
        public List<string> Validate()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(AccountId))
                errors.Add("Account ID is required.");

            if (string.IsNullOrWhiteSpace(SalesRepId))
                errors.Add("Sales Rep ID is required.");

            if (DeliveryDate == default)
                errors.Add("A valid delivery date is required.");

            if (Items.Count == 0)
                errors.Add("At least one item is required.");

            foreach (OrderItem item in Items)
            {
                if (item.Quantity <= 0)
                    errors.Add($"Quantity for item {item.ItemId} must be greater than zero.");
            }

            return errors;
        }

    }
}
