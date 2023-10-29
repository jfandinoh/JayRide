using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JayRide.Models;
using Newtonsoft.Json;

namespace JayRide.Services
{
    public class JayrideService : IJayrideService
    {
        public async Task<Quote> GetQuote()
        {
            Quote quote = new();
            try{
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest"))
                    {
                        System.Console.WriteLine(response);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            System.Console.WriteLine(apiResponse);

                            var json = JsonConvert.DeserializeObject<Quote>(apiResponse);

                            if (json!= null)
                                quote=json;
                        } 
                        else{
                            throw new Exception("QuoteRequest error");
                        }                   
                    }   
                }
                return quote;
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }
    }
}