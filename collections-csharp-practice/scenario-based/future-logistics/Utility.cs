using System;
using System.Text.RegularExpressions;

namespace FutureLogistics
{
    public class Utility
    {
        public static GoodsTransport parseDetails(string input)
        {
            string[] data = input.Split(':');

            string id = data[0];
            string date = data[1];
            int rating = int.Parse(data[2]);
            string type = data[3];

            if (type.Equals("BrickTransport", StringComparison.OrdinalIgnoreCase))
            {
                return new BrickTransport(id, date, rating,
                    float.Parse(data[4]),
                    int.Parse(data[5]),
                    float.Parse(data[6]));
            }
            else
            {
                return new TimberTransport(id, date, rating,
                    float.Parse(data[4]),
                    float.Parse(data[5]),
                    data[6],
                    float.Parse(data[7]));
            }
        }

        public static bool validateTransportId(string transportId)
        {
            bool valid = Regex.IsMatch(transportId, "^RTS[0-9]{3}[A-Z]$");
            if (!valid)
            {
                Console.WriteLine($"Transport id {transportId} is invalid");
                Console.WriteLine("Please provide a valid record");
            }
            return valid;
        }

        public static string findObjectType(GoodsTransport gt)
        {
            if (gt is BrickTransport)
                return "BrickTransport";
            else
                return "TimberTransport";
        }

        public static float GetVehiclePrice(string vehicle)
        {
            if (vehicle.Equals("Truck", StringComparison.OrdinalIgnoreCase))
                return 1000;
            if (vehicle.Equals("Lorry", StringComparison.OrdinalIgnoreCase))
                return 1700;
            return 3000;
        }
    }
}
