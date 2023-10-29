using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JayRide.Models;

namespace JayRide.Services
{
    public interface IJayrideService
    {
        Task<Quote> GetQuote();
    }
}