using ACMEDistrubuting_SWE3313_TeamAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ACMEDistrubuting_SWE3313_TeamAlpha.Services
{
    /// <summary>
    /// Handles "submitting" a completed order. This prototype runs stand-alone with no
    /// network or database connection, so submission/transmission is simulated by writing
    /// the order out as a JSON file under the Orders folder next to the executable. This
    /// stands in for the eventual database record.
    /// </summary>
    internal class OrderSubmissionService
    {
        /// <summary>Folder the simulated "database" order records are written to.</summary>
        private static readonly string OrdersFolder = Path.Combine(AppContext.BaseDirectory, "Orders");

        /// <summary>
        /// Validates and "submits" (writes to disk) the given order. Also writes a plain-text
        /// customer receipt alongside the JSON record so there's a human-readable copy of
        /// every order, matching the "customer receipt" report format called for in the
        /// system design doc.
        /// </summary>
        /// <paramater name="order">The order to submit.</param>
        /// <returns>The full path of the JSON file written.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the order fails validation.</exception>
        public static string Submit(Order order)
        {
            List<string> errors = order.Validate();
            if (errors.Count > 0)
                throw new InvalidOperationException(string.Join(Environment.NewLine, errors));

            Directory.CreateDirectory(OrdersFolder);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"order_{order.AccountId}_{timestamp}.json";
            string filePath = Path.Combine(OrdersFolder, fileName);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(order, options);

            File.WriteAllText(filePath, json);

            // Companion receipt, same name/timestamp so it's easy to match back to the record.
            string receiptFileName = $"receipt_{order.AccountId}_{timestamp}.txt";
            string receiptPath = Path.Combine(OrdersFolder, receiptFileName);
            File.WriteAllText(receiptPath, GenerateReceipt(order));

            return filePath;
        }

        /// <summary>
        /// Builds the customer-facing receipt text for a submitted order, formatted to match
        /// Acme's existing paper order form layout.
        /// </summary>
        public static string GenerateReceipt(Order order)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Acme Distributing");
            sb.AppendLine();
            sb.AppendLine($"Account ID#: {order.AccountId}");
            sb.AppendLine($"Delivery Date: {order.DeliveryDate:MM/dd/yyyy}");
            sb.AppendLine($"Sales Rep ID: {order.SalesRepId}");
            sb.AppendLine($"Delivery Rep ID: {order.DeliveryRepId}");
            sb.AppendLine();
            sb.AppendLine($"{"ID",-12}{"Item Name",-30}{"Quantity",-10}");

            foreach (OrderItem item in order.Items)
            {
                sb.AppendLine($"{item.ItemId,-12}{item.ItemName,-30}{item.Quantity,-10}");
            }

            sb.AppendLine();
            sb.AppendLine($"Total Items: {order.Items.Sum(i => i.Quantity)}");

            return sb.ToString();
        }

        /// <summary>
        /// Builds a daily summary report (management report format) aggregating every order
        /// on file for the given date. Reads back through <see cref="LoadAll"/>, so it reflects
        /// whatever has actually been "transmitted" so far.
        /// </summary>
        public static string GenerateDailySummary(DateTime date)
        {
            List<Order> ordersForDay = LoadAll()
                .Where(o => o.DeliveryDate.Date == date.Date)
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine("Acme Distributing - Daily Summary");
            sb.AppendLine($"Date: {date:MM/dd/yyyy}");
            sb.AppendLine($"Total Orders: {ordersForDay.Count}");
            sb.AppendLine($"Total Units: {ordersForDay.Sum(o => o.Items.Sum(i => i.Quantity))}");
            sb.AppendLine();

            foreach (Order order in ordersForDay)
            {
                int units = order.Items.Sum(i => i.Quantity);
                sb.AppendLine($"Account {order.AccountId} (Sales Rep {order.SalesRepId}): " +
                    $"{order.Items.Count} line item(s), {units} unit(s)");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Loads every previously submitted order from the Orders folder. Useful for a
        /// future "order history" screen or for the daily summary report.
        /// </summary>
        public static List<Order> LoadAll()
        {
            var orders = new List<Order>();

            if (!Directory.Exists(OrdersFolder))
                return orders;

            foreach (string file in Directory.GetFiles(OrdersFolder, "order_*.json"))
            {
                string json = File.ReadAllText(file);
                Order? order = JsonSerializer.Deserialize<Order>(json);
                if (order != null)
                    orders.Add(order);
            }

            return orders;
        }
    }
}