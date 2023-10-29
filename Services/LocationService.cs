using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using JayRide.Models;

namespace JayRide.Services
{
    public class LocationService : ILocationService
    {
        public async Task<Location> GetLocation(string IP)
        {
            Location location = new();
            try{
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://ip-api.com/json/"+IP))
                    {
                        System.Console.WriteLine(response);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            System.Console.WriteLine(apiResponse);

                            var json = JsonConvert.DeserializeAnonymousType(apiResponse,new 
                            { 
                                status =string.Empty,
                                city = string.Empty
                            });

                            if(json != null)
                            {
                                location.City = json.city;
                                if(json.status.ToLower().Equals("fail")){
                                    throw new Exception (apiResponse);
                                }
                            }
                        }                    
                    }   
                }
                return location;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
    }
}