using ACMEDistrubuting_SWE3313_TeamAlpha.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ACMEDistrubuting_SWE3313_TeamAlpha.Services
{
    internal class RouteDeterminationService
    {
        private static readonly string RouteFolder =
            Path.Combine(AppContext.BaseDirectory, "Routes");

        public static string Save(Route route)
        {
            List<string> errors = route.Validate();

            if (errors.Count > 0)
                throw new InvalidOperationException(
                    string.Join(Environment.NewLine, errors));

            Directory.CreateDirectory(RouteFolder);

            string timestamp =
                DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string jsonFile =
                Path.Combine(
                    RouteFolder,
                    $"route_{route.SalesRepId}_{timestamp}.json");

            var options =
                new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

            File.WriteAllText(
                jsonFile,
                JsonSerializer.Serialize(route, options));

            string report =
                Path.Combine(
                    RouteFolder,
                    $"RouteReport_{route.SalesRepId}_{timestamp}.txt");

            File.WriteAllText(
                report,
                GenerateReport(route));

            return jsonFile;
        }

        public static List<Route> LoadAll()
        {
            List<Route> routes = new();

            if (!Directory.Exists(RouteFolder))
                return routes;

            foreach (string file in Directory.GetFiles(RouteFolder, "*.json"))
            {
                Route? route =
                    JsonSerializer.Deserialize<Route>(
                        File.ReadAllText(file));

                if (route != null)
                    routes.Add(route);
            }

            return routes;
        }

        public static void AddStop(Route route, RouteStop stop)
        {
            stop.StopNumber = route.Stops.Count + 1;
            route.Stops.Add(stop);
        }

        public static void RemoveStop(Route route, int stopNumber)
        {
            RouteStop? stop =
                route.Stops.FirstOrDefault(
                    s => s.StopNumber == stopNumber);

            if (stop == null)
                return;

            route.Stops.Remove(stop);

            Renumber(route);
        }

        public static void MoveStopUp(Route route, int stopNumber)
        {
            if (stopNumber <= 1)
                return;

            RouteStop current =
                route.Stops.First(s => s.StopNumber == stopNumber);

            RouteStop previous =
                route.Stops.First(s => s.StopNumber == stopNumber - 1);

            current.StopNumber--;
            previous.StopNumber++;

            route.Stops = route.Stops
                .OrderBy(s => s.StopNumber)
                .ToList();
        }

        public static void MoveStopDown(Route route, int stopNumber)
        {
            if (stopNumber >= route.Stops.Count)
                return;

            RouteStop current =
                route.Stops.First(s => s.StopNumber == stopNumber);

            RouteStop next =
                route.Stops.First(s => s.StopNumber == stopNumber + 1);

            current.StopNumber++;
            next.StopNumber--;

            route.Stops = route.Stops
                .OrderBy(s => s.StopNumber)
                .ToList();
        }

        private static void Renumber(Route route)
        {
            int i = 1;

            foreach (RouteStop stop in route.Stops)
            {
                stop.StopNumber = i++;
            }
        }

        public static string GenerateReport(Route route)
        {
            StringBuilder sb = new();

            sb.AppendLine("=================================");
            sb.AppendLine("ACME Distributing Route Sheet");
            sb.AppendLine("=================================");
            sb.AppendLine();

            sb.AppendLine($"Sales Rep : {route.SalesRepId}");
            sb.AppendLine($"Date      : {route.RouteDate:d}");
            sb.AppendLine();

            foreach (RouteStop stop in route.Stops.OrderBy(s => s.StopNumber))
            {
                sb.AppendLine($"STOP #{stop.StopNumber}");
                sb.AppendLine($"Customer : {stop.CustomerName}");
                sb.AppendLine($"ID       : {stop.CustomerId}");
                sb.AppendLine($"Address  : {stop.Address}");
                sb.AppendLine($"Window   : {stop.DeliveryWindow}");
                sb.AppendLine($"Dock     : {(stop.HasLoadingDock ? "YES" : "NO")}");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}