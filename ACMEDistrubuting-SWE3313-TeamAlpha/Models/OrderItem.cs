using System;
using System.Collections.Generic;
using System.Text;

namespace ACMEDistrubuting_SWE3313_TeamAlpha.Models
{
    internal class OrderItem
    {
        public string ItemId { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public OrderItem() { }

        public OrderItem(string itemId, string itemName, int quantity)
        {
            ItemId = itemId;
            ItemName = itemName;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{ItemId} - {ItemName} x{Quantity}";
        }
    }
}