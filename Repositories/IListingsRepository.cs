using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JayRide.Models;

namespace JayRide.Repositories
{
    public interface IListingsRepository
    {
        Quote GetListingByNumberOfPassengers(int passengers, Quote quote);
    }
}