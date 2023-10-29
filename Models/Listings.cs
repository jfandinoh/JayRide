using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JayRide.Models
{
    public class Listing
    {
        public string? name { get; set; }
        public double? pricePerPassenger { get; set; }
        public double? priceTotalPassenger { get; set; }
        public vehicleType vehicleType { get; set; }
    }

    public class Quote
    {
        public string? from { get; set; }
        public string? to { get; set; }
        public List<Listing> listings { get; set; }

        public Quote(){
            listings = new List<Listing>();
        }
    }
    public class vehicleType
    {
        public string? name { get; set; }
        public int maxPassengers { get; set; }
    }

    public class QuoteResponse
    {
        public string? from { get; set; }
        public string? to { get; set; }
        public List<Listing> listings { get; set; }
    }

    public class ListingsResponse
    {
        public string? name { get; set; }
        public double? pricePerPassenger { get; set; }
        public double? priceTotalPassenger { get; set; }
        public vehicleType vehicleType { get; set; }
    }
}