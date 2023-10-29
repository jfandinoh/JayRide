using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JayRide.Models;

namespace JayRide.Repositories
{
    public class ListingsRepository : IListingsRepository
    {
        public Quote GetListingByNumberOfPassengers(int passengers, Quote quote)
        {
            try{
                Quote filterQuote = new();
                var listingsByPassangers = quote.listings.Where(x => x.vehicleType.maxPassengers >= passengers).ToList();

                filterQuote.from = quote.from;
                filterQuote.to = quote.to;
                
                foreach(Listing listing in listingsByPassangers){
                    listing.priceTotalPassenger = listing.pricePerPassenger * passengers;
                    filterQuote.listings.Add(listing);
                }
                
                filterQuote.listings = filterQuote.listings.OrderBy(x => x.priceTotalPassenger).ToList();

                return filterQuote;
            }
            catch(Exception ex){
                throw new Exception("Error getting list by number of passengers");
            }
        }
    }
}