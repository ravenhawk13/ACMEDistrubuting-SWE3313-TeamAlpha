using System;

namespace ACMEDistrubuting_SWE3313_TeamAlpha.Models
{
    /// <summary>Represents a single sellable item from Acme's master product list.</summary>
    internal class Product
    {
        public string ItemId { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;

        public Product() { }

        public Product(string itemId, string itemName)
        {
            ItemId = itemId;
            ItemName = itemName;
        }

        /// <summary>Display form used for the product textbox's autocomplete suggestions.</summary>
        public override string ToString() => $"{ItemId} - {ItemName}";
    }
}