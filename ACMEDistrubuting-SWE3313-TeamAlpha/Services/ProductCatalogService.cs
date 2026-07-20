using ACMEDistrubuting_SWE3313_TeamAlpha.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ACMEDistrubuting_SWE3313_TeamAlpha.Services
{
    /// <summary>
    /// Loads Acme's master product list so the order screen has real inventory items to pick
    /// from, instead of a free-text field with nothing backing it. The catalog ships as a CSV
    /// file (ItemId,ItemName) alongside the executable; this stands in for a future database
    /// lookup the same way OrderSubmissionService's JSON files stand in for order records.
    /// </summary>
    internal class ProductCatalogService
    {
        /// <summary>CSV file the product catalog is read from. Must be copied to the output
        /// directory alongside the executable (Build Action: Content, Copy if newer).</summary>
        private static readonly string CatalogFile =
            Path.Combine(AppContext.BaseDirectory, "Products", "product_catalog.csv");

        /// <summary>
        /// Reads every product out of the catalog file. Returns an empty list (rather than
        /// throwing) if the file hasn't been deployed yet, so a missing catalog degrades to
        /// "no suggestions" instead of crashing the order screen.
        /// </summary>
        public static List<Product> LoadCatalog()
        {
            var products = new List<Product>();

            if (!File.Exists(CatalogFile))
                return products;

            // Skip the header row (ItemId,ItemName).
            foreach (string line in File.ReadAllLines(CatalogFile).Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',', 2);
                if (parts.Length == 2 && !string.IsNullOrWhiteSpace(parts[0]))
                    products.Add(new Product(parts[0].Trim(), parts[1].Trim()));
            }

            return products;
        }
    }
}